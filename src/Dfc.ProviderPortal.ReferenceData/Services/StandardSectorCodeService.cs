using Dfc.ProviderPortal.Packages;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Models;
using Dfc.ProviderPortal.ReferenceData.Settings;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Services
{
    public class StandardSectorCodeService : IStandardSectorCodeService
    {
        private readonly ICosmosDbHelper _cosmosDbHelper;
        private readonly ICosmosDbSettings _cosmosDbSettings;
        private readonly ICosmosDbCollectionSettings _cosmosDbCollectionSettings;

        public StandardSectorCodeService(
            ICosmosDbHelper cosmosDbHelper,
            IOptions<CosmosDbSettings> cosmosDbSettings,
            IOptions<CosmosDbCollectionSettings> cosmosDbCollectionSettings) : this(cosmosDbHelper, cosmosDbSettings.Value, cosmosDbCollectionSettings.Value)
        {
            Throw.IfNull(cosmosDbHelper, nameof(cosmosDbHelper));
            Throw.IfNull(cosmosDbSettings, nameof(cosmosDbSettings));
            Throw.IfNull(cosmosDbCollectionSettings, nameof(cosmosDbCollectionSettings));
        }

        public StandardSectorCodeService(
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

        public Task<IEnumerable<StandardSectorCode>> GetAllAsync()
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.StandardSectorCodesCollectionId);
            var sql = $"SELECT * FROM c";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<StandardSectorCode>(uri, sql, options).AsEnumerable();
            return Task.FromResult(results);
        }

        public Task<StandardSectorCode> GetByStandardSectorCodeIdAsync(int standardSectorCodeId)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.StandardSectorCodesCollectionId);
            var sql = $"SELECT * FROM c WHERE c.StandardSectorCodeId = '{standardSectorCodeId}'";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<StandardSectorCode>(uri, sql, options).AsEnumerable().FirstOrDefault();
            return Task.FromResult(results);
        }
    }
}