using Dfc.ProviderPortal.ReferenceData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface ISectorSubjectAreaTier1Service
    {
        Task<IEnumerable<SectorSubjectAreaTier1>> GetAllAsync();

        Task<SectorSubjectAreaTier1> GetBySectorSubjectAreaTier1IdAsync(decimal sectorSubjectAreaTier1Id);
    }
}