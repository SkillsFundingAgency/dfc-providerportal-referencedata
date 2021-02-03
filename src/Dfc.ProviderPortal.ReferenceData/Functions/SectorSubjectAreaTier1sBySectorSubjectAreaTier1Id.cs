using System.Threading.Tasks;
using Dfc.ProviderPortal.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public class SectorSubjectAreaTier1sBySectorSubjectAreaTier1Id
    {
        private readonly ISectorSubjectAreaTier1Service _sectorSubjectAreaTier1Service;

        public SectorSubjectAreaTier1sBySectorSubjectAreaTier1Id(
            ISectorSubjectAreaTier1Service sectorSubjectAreaTier1Service)
        {
            _sectorSubjectAreaTier1Service = sectorSubjectAreaTier1Service;
        }

        [FunctionName("SectorSubjectAreaTier1sBySectorSubjectAreaTier1Id")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "referencedata/sector-subject-area-tier-1s/{sectorSubjectAreaTier1Id}")] HttpRequest req,
            decimal sectorSubjectAreaTier1Id)
        {
            var results = await _sectorSubjectAreaTier1Service.GetBySectorSubjectAreaTier1IdAsync(sectorSubjectAreaTier1Id);

            return new JsonResult(results);
        }
    }
}