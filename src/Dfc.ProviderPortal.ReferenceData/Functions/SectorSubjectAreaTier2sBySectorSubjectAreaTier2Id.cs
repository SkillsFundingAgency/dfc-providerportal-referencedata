using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class SectorSubjectAreaTier2sBySectorSubjectAreaTier2Id
    {
        private readonly ISectorSubjectAreaTier2Service _sectorSubjectAreaTier2Service;

        public SectorSubjectAreaTier2sBySectorSubjectAreaTier2Id(
            ISectorSubjectAreaTier2Service sectorSubjectAreaTier2Service)
        {
            _sectorSubjectAreaTier2Service = sectorSubjectAreaTier2Service;
        }

        [FunctionName("SectorSubjectAreaTier2sBySectorSubjectAreaTier2Id")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/sector-subject-area-tier-2s/{sectorSubjectAreaTier2Id}")] HttpRequest req,
            decimal sectorSubjectAreaTier2Id)
        {
            var results = await _sectorSubjectAreaTier2Service.GetBySectorSubjectAreaTier2IdAsync(sectorSubjectAreaTier2Id);

            return new JsonResult(results);
        }
    }
}