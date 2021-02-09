using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ApprenticeshipsStandards
    {
        private readonly IApprenticeshipStandardService _apprenticeshipStandardService;

        public ApprenticeshipsStandards(IApprenticeshipStandardService apprenticeshipStandardService)
        {
            _apprenticeshipStandardService = apprenticeshipStandardService;
        }

        [FunctionName("ApprenticeshipsStandards")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/apprenticeship-standards")] HttpRequest req)
        {
            var results = await _apprenticeshipStandardService.GetAllAsync();

            return new JsonResult(results);
        }
    }
}