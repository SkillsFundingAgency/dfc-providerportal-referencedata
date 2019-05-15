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
    public class ApprenticeshipFrameworkService : IApprenticeshipFrameworkService
    {
        private readonly ICosmosDbHelper _cosmosDbHelper;
        private readonly ICosmosDbSettings _cosmosDbSettings;
        private readonly ICosmosDbCollectionSettings _cosmosDbCollectionSettings;

        public ApprenticeshipFrameworkService(
            ICosmosDbHelper cosmosDbHelper,
            IOptions<CosmosDbSettings> cosmosDbSettings,
            IOptions<CosmosDbCollectionSettings> cosmosDbCollectionSettings) : this(cosmosDbHelper, cosmosDbSettings.Value, cosmosDbCollectionSettings.Value)
        {
            Throw.IfNull(cosmosDbHelper, nameof(cosmosDbHelper));
            Throw.IfNull(cosmosDbSettings, nameof(cosmosDbSettings));
            Throw.IfNull(cosmosDbCollectionSettings, nameof(cosmosDbCollectionSettings));
        }

        public ApprenticeshipFrameworkService(
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

        public Task<IEnumerable<ApprenticeshipFramework>> GetAllAsync()
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.FrameworksCollectionId);
            var sql = $"SELECT * FROM c";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<ApprenticeshipFramework>(uri, sql, options).AsEnumerable();
            return Task.FromResult(results);
        }

        public Task<IEnumerable<ApprenticeshipFramework>> GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAsync(int frameworkCode, int progTypeId)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.FrameworksCollectionId);
            var sql = $"SELECT * FROM c WHERE c.FrameworkCode = {frameworkCode} AND c.ProgType = {progTypeId}";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<ApprenticeshipFramework>(uri, sql, options).AsEnumerable();
            return Task.FromResult(results);
        }

        public Task<ApprenticeshipFramework> GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAndPathwayCodeAsync(int frameworkCode, int progTypeId, int pathwayCode)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.FrameworksCollectionId);
            var sql = $"SELECT * FROM c WHERE c.FrameworkCode = {frameworkCode} AND c.ProgType = {progTypeId} AND c.PathwayCode = {pathwayCode}";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<ApprenticeshipFramework>(uri, sql, options).AsEnumerable().FirstOrDefault();
            return Task.FromResult(results);
        }

        public Task<IEnumerable<ApprenticeshipFramework>> GetApprenticeshipFrameworkByFrameworkCodeAsync(int frameworkCode)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(_cosmosDbSettings.DatabaseId, _cosmosDbCollectionSettings.FrameworksCollectionId);
            var sql = $"SELECT * FROM c WHERE c.FrameworkCode = {frameworkCode}";
            var options = new FeedOptions { EnableCrossPartitionQuery = true, MaxItemCount = -1 };
            var client = _cosmosDbHelper.GetClient();
            var results = client.CreateDocumentQuery<ApprenticeshipFramework>(uri, sql, options).AsEnumerable();
            return Task.FromResult(results);
        }
    }
}