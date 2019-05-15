using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Dfc.ProviderPortal.ReferenceData.Helpers;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.ReferenceData.Models;
using Dfc.ProviderPortal.ReferenceData.Services;
using Dfc.ProviderPortal.ReferenceData.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public static class ApprenticeshipsFrameworks
    {
        [FunctionName("ApprenticeshipsFrameworks")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/apprenticeship-frameworks")] HttpRequest req,
            ILogger log)
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
            var results = await apprenticeshipFrameworkService.GetAllAsync();

            return new JsonResult(results, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}