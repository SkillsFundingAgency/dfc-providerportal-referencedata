using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class ProgTypes
    {
        private readonly IProgTypeService _progTypeService;

        public ProgTypes(IProgTypeService progTypeService)
        {
            _progTypeService = progTypeService;
        }

        [FunctionName("ProgTypes")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/prog-types")] HttpRequest req)
        {
            var results = await _progTypeService.GetAllAsync();

            return new JsonResult(results);
        }
    }
}