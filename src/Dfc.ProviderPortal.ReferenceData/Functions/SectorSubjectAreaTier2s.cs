using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class SectorSubjectAreaTier2s
    {
        private readonly ISectorSubjectAreaTier2Service _sectorSubjectAreaTier2Service;

        public SectorSubjectAreaTier2s(
            ISectorSubjectAreaTier2Service sectorSubjectAreaTier2Service)
        {
            _sectorSubjectAreaTier2Service = sectorSubjectAreaTier2Service;
        }

        [FunctionName("SectorSubjectAreaTier2s")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/sector-subject-area-tier-2s")] HttpRequest req)
        {
            var results = await _sectorSubjectAreaTier2Service.GetAllAsync();

            return new JsonResult(results);
        }
    }
}