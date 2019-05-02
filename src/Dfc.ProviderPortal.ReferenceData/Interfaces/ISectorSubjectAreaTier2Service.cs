using Dfc.ProviderPortal.ReferenceData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface ISectorSubjectAreaTier2Service
    {
        Task<IEnumerable<SectorSubjectAreaTier2>> GetAllAsync();

        Task<SectorSubjectAreaTier2> GetBySectorSubjectAreaTier2IdAsync(decimal sectorSubjectAreaTier2Id);
    }
}