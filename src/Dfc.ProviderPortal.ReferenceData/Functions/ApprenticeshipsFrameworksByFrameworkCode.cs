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
    public static class ApprenticeshipsFrameworksByFrameworkCode
    {
        [FunctionName("ApprenticeshipsFrameworksByFrameworkCode")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/apprenticeship-frameworks/{frameworkCode}")] HttpRequest req,
            ILogger log,
            [Inject] IApprenticeshipFrameworkService apprenticeshipFrameworkService,
            int frameworkCode)
        {
            var result = await apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAsync(frameworkCode);
            if (result == null) return new NotFoundResult();

            return new JsonResult(result, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}