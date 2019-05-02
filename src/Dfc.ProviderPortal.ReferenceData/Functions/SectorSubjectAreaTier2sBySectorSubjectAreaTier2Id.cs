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
    public static class SectorSubjectAreaTier2sBySectorSubjectAreaTier2Id
    {
        [FunctionName("SectorSubjectAreaTier2sBySectorSubjectAreaTier2Id")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/sector-subject-area-tier-2s/{sectorSubjectAreaTier2Id}")] HttpRequest req,
            ILogger log,
            [Inject] ISectorSubjectAreaTier2Service sectorSubjectAreaTier2Service,
            decimal sectorSubjectAreaTier2Id)
        {
            var result = await sectorSubjectAreaTier2Service.GetBySectorSubjectAreaTier2IdAsync(sectorSubjectAreaTier2Id);
            if (result == null) return new NotFoundResult();

            return new JsonResult(result, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }
}