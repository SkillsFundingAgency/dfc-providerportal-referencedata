using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public static class ProgTypesByProgTypeId
    {
        [FunctionName("ProgTypesByProgTypeId")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/prog-types/{progTypeId}")] HttpRequest req,
            ILogger log,
            [Inject] IProgTypeService progTypeService,
            int progTypeId)
        {
            var result = await progTypeService.GetByProgTypeIdAsync(progTypeId);
            if (result == null) return new NotFoundResult();

            return new JsonResult(result, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}