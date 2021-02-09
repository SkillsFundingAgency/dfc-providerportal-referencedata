using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ProgTypesByProgTypeId
    {
        private readonly IProgTypeService _progTypeService;

        public ProgTypesByProgTypeId(IProgTypeService progTypeService)
        {
            _progTypeService = progTypeService;
        }

        [FunctionName("ProgTypesByProgTypeId")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/prog-types/{progTypeId}")] HttpRequest req,
            int progTypeId)
        {
            var results = await _progTypeService.GetByProgTypeIdAsync(progTypeId);

            return new JsonResult(results);
        }
    }
}