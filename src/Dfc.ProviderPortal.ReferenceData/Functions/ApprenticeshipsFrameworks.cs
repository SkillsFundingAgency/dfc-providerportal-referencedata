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
    public static class ApprenticeshipsFrameworks
    {
        [FunctionName("ApprenticeshipsFrameworks")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/apprenticeship-frameworks")] HttpRequest req,
            ILogger log,
            [Inject] IApprenticeshipFrameworkService apprenticeshipFrameworkService)
        {
            var results = await apprenticeshipFrameworkService.GetAllAsync();

            return new JsonResult(results, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}