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
    public static class SectorSubjectAreaTier1sBySectorSubjectAreaTier1Id
    {
        [FunctionName("SectorSubjectAreaTier1sBySectorSubjectAreaTier1Id")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/sector-subject-area-tier-1s/{sectorSubjectAreaTier1Id}")] HttpRequest req,
            ILogger log,
            [Inject] ISectorSubjectAreaTier1Service sectorSubjectAreaTier1Service,
            decimal sectorSubjectAreaTier1Id)
        {
            var result = await sectorSubjectAreaTier1Service.GetBySectorSubjectAreaTier1IdAsync(sectorSubjectAreaTier1Id);
            if (result == null) return new NotFoundResult();

            return new JsonResult(result, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}