using Dfc.ProviderPortal.ReferenceData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IStandardSectorCodeService
    {
        Task<IEnumerable<StandardSectorCode>> GetAllAsync();

        Task<StandardSectorCode> GetByStandardSectorCodeIdAsync(int standardSectorCodeId);
    }
}