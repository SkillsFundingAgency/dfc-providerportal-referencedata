using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/apprenticeship-frameworks/{frameworkCode}/prog-type/{progtypeId}/pathway-code/{pathwayCode}")] HttpRequest req,
            ILogger log,
            [Inject] IApprenticeshipFrameworkService apprenticeshipFrameworkService,
            int frameworkCode,
            int progTypeId,
            int pathwayCode)
        {
            try
            {
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