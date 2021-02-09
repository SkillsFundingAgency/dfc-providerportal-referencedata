using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ApprenticeshipsFrameworksByFrameworkCode
    {
        private readonly IApprenticeshipFrameworkService _apprenticeshipFrameworkService;

        public ApprenticeshipsFrameworksByFrameworkCode(
            IApprenticeshipFrameworkService apprenticeshipFrameworkService)
        {
            _apprenticeshipFrameworkService = apprenticeshipFrameworkService;
        }

        [FunctionName("ApprenticeshipsFrameworksByFrameworkCode")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/apprenticeship-frameworks/{frameworkCode}")] HttpRequest req,
            int frameworkCode)
        {
            var results = await _apprenticeshipFrameworkService.GetApprenticeshipFrameworkByFrameworkCodeAsync(frameworkCode);

            return new JsonResult(results);
        }
    }
}