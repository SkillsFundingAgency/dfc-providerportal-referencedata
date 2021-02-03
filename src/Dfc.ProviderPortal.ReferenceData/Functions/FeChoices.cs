using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class FeChoices
    {
        private readonly IFeChoiceService _feChoiceService;

        public FeChoices(IFeChoiceService feChoiceService)
        {
            _feChoiceService = feChoiceService;
        }

        [FunctionName("FeChoices")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/fe-choices")] HttpRequest req)
        {
            var results = await _feChoiceService.GetAllAsync();
            return new JsonResult(results);
        }
    }
}