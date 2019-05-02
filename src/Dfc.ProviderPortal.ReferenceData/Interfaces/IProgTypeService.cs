using Dfc.ProviderPortal.ReferenceData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IProgTypeService
    {
        Task<IEnumerable<ProgType>> GetAllAsync();

        Task<ProgType> GetByProgTypeIdAsync(int progTypeId);
    }
}