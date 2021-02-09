using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ApprenticeshipsFrameworks
    {
        private readonly IApprenticeshipFrameworkService _apprenticeshipFrameworkService;

        public ApprenticeshipsFrameworks(IApprenticeshipFrameworkService apprenticeshipFrameworkService)
        {
            _apprenticeshipFrameworkService = apprenticeshipFrameworkService;
        }

        [FunctionName("ApprenticeshipsFrameworks")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/apprenticeship-frameworks")] HttpRequest req)
        {
            var results = await _apprenticeshipFrameworkService.GetAllAsync();

            return new JsonResult(results);
        }
    }
}