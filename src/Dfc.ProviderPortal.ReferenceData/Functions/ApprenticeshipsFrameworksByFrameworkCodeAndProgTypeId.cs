using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeId
    {
        private readonly IApprenticeshipFrameworkService _apprenticeshipFrameworkService;

        public ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeId(
            IApprenticeshipFrameworkService apprenticeshipFrameworkService)
        {
            _apprenticeshipFrameworkService = apprenticeshipFrameworkService;
        }

        [FunctionName("ApprenticeshipsFrameworksByFrameworkCodeAndProgTypeId")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/apprenticeship-frameworks/{frameworkCode}/prog-type/{progTypeId}")] HttpRequest req,
            int frameworkCode,
            int progTypeId)
        {
            var results = await _apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAsync(frameworkCode, progTypeId);

            return new JsonResult(results);
        }
    }
}