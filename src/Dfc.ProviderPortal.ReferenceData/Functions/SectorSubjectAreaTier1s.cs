using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class SectorSubjectAreaTier1s
    {
        private readonly ISectorSubjectAreaTier1Service _sectorSubjectAreaTier1Service;

        public SectorSubjectAreaTier1s(
            ISectorSubjectAreaTier1Service sectorSubjectAreaTier1Service)
        {
            _sectorSubjectAreaTier1Service = sectorSubjectAreaTier1Service;
        }

        [FunctionName("SectorSubjectAreaTier1s")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/sector-subject-area-tier-1s")] HttpRequest req)
        {
            var results = await _sectorSubjectAreaTier1Service.GetAllAsync();

            return new JsonResult(results);
        }
    }
}