using Dfc.ProviderPortal.Packages;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Models;
using Dfc.ProviderPortal.ReferenceData.Settings;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Services
{
    public class FeChoiceService : IFeChoiceService
    {
        private readonly ICosmosDbHelper _cosmosDbHelper;
        private readonly ICosmosDbSettings _cosmosDbSettings;
        private readonly ICosmosDbCollectionSettings _cosmosDbCollectionSettings;

        public FeChoiceService(
            ICosmosDbHelper cosmosDbHelper,
            IOptions<CosmosDbSettings> cosmosDbSettings,
            IOptions<CosmosDbCollectionSettings> cosmosDbCollectionSettings) : this(cosmosDbHelper, cosmosDbSettings.Value, cosmosDbCollectionSettings.Value)
        {
            Throw.IfNull(cosmosDbHelper, nameof(cosmosDbHelper));
            Throw.IfNull(cosmosDbSettings, nameof(cosmosDbSettings));
            Throw.IfNull(cosmosDbCollectionSettings, nameof(cosmosDbCollectionSettings));
        }

        public FeChoiceService(
            ICosmosDbHelper cosmosDbHelper,
            CosmosDbSettings cosmosDbSettings,
            CosmosDbCollectionSettings cosmosDbCollectionSettings)
        {
            Throw.IfNull(cosmosDbHelper, nameof(cosmosDbHelper));
            Throw.IfNull(cosmosDbSettings, nameof(cosmosDbSettings));
            Throw.IfNull(cosmosDbCollectionSettings, nameof(cosmosDbCollectionSettings));

            _cosmosDbHelper = cosmosDbHelper;
            _cosmosDbSettings = cosmosDbSettings;
            _cosmosDbCollectionSettings = cosmosDbCollectionSettings;
        }

        public async Task<IEnumerable<FeChoice>> GetAllAsync()
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.FeChoicesCollectionId);
            var sql = $"SELECT * FROM c";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };

            var client = _cosmosDbHelper.GetClient();
            var query = client.CreateDocumentQuery<FeChoice>(uri, sql, options).AsDocumentQuery();

            var results = new List<FeChoice>();

            while (query.HasMoreResults)
            {
                var response = await query.ExecuteNextAsync<FeChoice>();
                results.AddRange(response);
            }

            return results;
        }

        public async Task<FeChoice> GetByUKPRNAsync(int ukprn)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.FeChoicesCollectionId);
            var sql = $"SELECT * FROM c WHERE c.UKPRN = {ukprn}";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };

            var client = _cosmosDbHelper.GetClient();
            var query = client.CreateDocumentQuery<FeChoice>(uri, sql, options).AsDocumentQuery();

            var results = await query.ExecuteNextAsync();

            return results.FirstOrDefault();
        }
    }
}