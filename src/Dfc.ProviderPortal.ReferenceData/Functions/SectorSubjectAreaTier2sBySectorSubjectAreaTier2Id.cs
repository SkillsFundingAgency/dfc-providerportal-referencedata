using Dfc.ProviderPortal.ReferenceData.Helpers;
using Dfc.ProviderPortal.ReferenceData.Services;
using Dfc.ProviderPortal.ReferenceData.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public static class SectorSubjectAreaTier2sBySectorSubjectAreaTier2Id
    {
        [FunctionName("SectorSubjectAreaTier2sBySectorSubjectAreaTier2Id")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/sector-subject-area-tier-2s/{sectorSubjectAreaTier2Id}")] HttpRequest req,
            ILogger log,
            decimal sectorSubjectAreaTier2Id)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var cosmosDbSettings = new CosmosDbSettings();
                var cosmosDbCollectionSettings = new CosmosDbCollectionSettings();
                configuration.Bind(nameof(CosmosDbSettings), cosmosDbSettings);
                configuration.Bind(nameof(CosmosDbCollectionSettings), cosmosDbCollectionSettings);

                var sectorSubjectAreaTier2Service = new SectorSubjectAreaTier2Service(new CosmosDbHelper(cosmosDbSettings), cosmosDbSettings, cosmosDbCollectionSettings);
                var results = await sectorSubjectAreaTier2Service.GetBySectorSubjectAreaTier2IdAsync(sectorSubjectAreaTier2Id);

                if (results == null) new NotFoundResult();

                return new JsonResult(results, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}