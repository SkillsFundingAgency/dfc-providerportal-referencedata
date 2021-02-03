using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ApprenticeshipsStandardsByStandardCode
    {
        private readonly IApprenticeshipStandardService _apprenticeshipStandardService;

        public ApprenticeshipsStandardsByStandardCode(IApprenticeshipStandardService apprenticeshipStandardService)
        {
            _apprenticeshipStandardService = apprenticeshipStandardService;
        }

        [FunctionName("ApprenticeshipsStandardsByStandardCode")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/apprenticeship-standards/{standardCode}")] HttpRequest req,
            int standardCode)
        {
            var results = await _apprenticeshipStandardService.GetApprenticeshipStandardByStandardCodeAsync(standardCode);

            return new JsonResult(results);
        }
    }
}