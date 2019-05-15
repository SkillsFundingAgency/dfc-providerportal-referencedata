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
    public static class FeChoicesByUpin
    {
        [FunctionName("FeChoicesByUpin")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/fe-choices/{upin}")] HttpRequest req,
            ILogger log,
            int upin)
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

                var feChoiceService = new FeChoiceService(new CosmosDbHelper(cosmosDbSettings), cosmosDbSettings, cosmosDbCollectionSettings);
                var results = await feChoiceService.GetByUpinAsync(upin);

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