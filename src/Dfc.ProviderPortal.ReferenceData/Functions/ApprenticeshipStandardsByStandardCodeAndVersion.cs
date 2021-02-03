using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ApprenticeshipStandardByStandardCodeAndVersion
    {
        private readonly IApprenticeshipStandardService _apprenticeshipStandardService;

        public ApprenticeshipStandardByStandardCodeAndVersion(
            IApprenticeshipStandardService apprenticeshipStandardService)
        {
            _apprenticeshipStandardService = apprenticeshipStandardService;
        }

        [FunctionName("ApprenticeshipStandardByStandardCodeAndVersion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/apprenticeship-standards/{standardCode}/version/{version}")] HttpRequest req,
            int standardCode,
            int version)
        {
            var results = await _apprenticeshipStandardService.GetApprenticeshipStandardByStandardCodeAndVersionAsync(standardCode, version);

            return new JsonResult(results);
        }
    }
}