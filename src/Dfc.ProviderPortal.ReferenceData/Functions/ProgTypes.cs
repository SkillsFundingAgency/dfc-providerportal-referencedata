using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Newtonsoft.Json.Serialization;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public static class ProgTypes
    {
        [FunctionName("ProgTypes")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/prog-types")] HttpRequest req,
            ILogger log,
            [Inject] IProgTypeService progTypeService)
        {
            var results = await progTypeService.GetAllAsync();

            return new JsonResult(results, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}
