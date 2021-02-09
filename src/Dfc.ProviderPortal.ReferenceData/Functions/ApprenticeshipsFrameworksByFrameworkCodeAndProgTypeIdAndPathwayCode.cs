using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAndPathwayCode
    {
        private readonly IApprenticeshipFrameworkService _apprenticeshipFrameworkService;

        public ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAndPathwayCode(
            IApprenticeshipFrameworkService apprenticeshipFrameworkService)
        {
            _apprenticeshipFrameworkService = apprenticeshipFrameworkService;
        }

        [FunctionName("ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeIdAndPathwayCode")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/apprenticeship-frameworks/{frameworkCode}/prog-type/{progTypeId}/pathway-code/{pathwayCode}")] HttpRequest req,
            int frameworkCode,
            int progTypeId,
            int pathwayCode)
        {
            var results = await _apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAndPathwayCodeAsync(frameworkCode, progTypeId, pathwayCode);

            return new JsonResult(results);
        }
    }
}