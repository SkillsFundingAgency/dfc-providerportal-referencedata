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
    public static class ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAndPathwayCode
    {
        [FunctionName("ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAndPathwayCode")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/apprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}/pathway-code/{pathwayCode}")] HttpRequest req,
            ILogger log,
            int frameworkCode,
            int progTypeId,
            int pathwayCode)
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

                var apprenticeshipFrameworkService = new ApprenticeshipFrameworkService(new CosmosDbHelper(cosmosDbSettings), cosmosDbSettings, cosmosDbCollectionSettings);
                var results = await apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAndPathwayCodeAsync(frameworkCode, progTypeId, pathwayCode);

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