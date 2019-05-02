using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public static class SectorSubjectAreaTier1s
    {
        [FunctionName("SectorSubjectAreaTier1s")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/sector-subject-area-tier-1s")] HttpRequest req,
            ILogger log,
            [Inject] ISectorSubjectAreaTier1Service sectorSubjectAreaTier1Service)
        {
            var results = await sectorSubjectAreaTier1Service.GetAllAsync();

            return new JsonResult(results, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}