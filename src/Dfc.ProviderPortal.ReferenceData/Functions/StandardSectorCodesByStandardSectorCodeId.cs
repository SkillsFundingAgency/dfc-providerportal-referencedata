using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class StandardSectorCodesByStandardSectorCodeId
    {
        private readonly IStandardSectorCodeService _standardSectorCodeService;

        public StandardSectorCodesByStandardSectorCodeId(IStandardSectorCodeService standardSectorCodeService)
        {
            _standardSectorCodeService = standardSectorCodeService;
        }

        [FunctionName("StandardSectorCodesByStandardSectorCodeId")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/standard-sector-codes/{standardSectorCodeId}")] HttpRequest req,
            int standardSectorCodeId)
        {
            var results = await _standardSectorCodeService.GetByStandardSectorCodeIdAsync(standardSectorCodeId);

            return new JsonResult(results);
        }
    }
}