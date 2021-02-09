using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class StandardSectorCodes
    {
        private readonly IStandardSectorCodeService _standardSectorCodeService;

        public StandardSectorCodes(IStandardSectorCodeService standardSectorCodeService)
        {
            _standardSectorCodeService = standardSectorCodeService;
        }

        [FunctionName("StandardSectorCodes")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/standard-sector-codes")] HttpRequest req)
        {
            var results = await _standardSectorCodeService.GetAllAsync();

            return new JsonResult(results);
        }
    }
}