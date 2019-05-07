using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public static class ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeId
    {
        [FunctionName("ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeId")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/apprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}")] HttpRequest req,
            ILogger log,
            [Inject] IApprenticeshipFrameworkService apprenticeshipFrameworkService,
            int frameworkCode,
            int progTypeId)
        {
            var result = await apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAsync(frameworkCode, progTypeId);
            if (result == null) return new NotFoundResult();

            return new JsonResult(result, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}
