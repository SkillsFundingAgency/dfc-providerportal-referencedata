using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class FeChoicesByUKPRN
    {
        private readonly IFeChoiceService _feChoiceService;

        public FeChoicesByUKPRN(IFeChoiceService feChoiceService)
        {
            _feChoiceService = feChoiceService;
        }

        [FunctionName("FeChoicesByUKPRN")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/fe-choices/{ukprn}")] HttpRequest req,
            int ukprn)
        {
            var results = await _feChoiceService.GetByUKPRNAsync(ukprn);

            return new JsonResult(results);
        }
    }
}