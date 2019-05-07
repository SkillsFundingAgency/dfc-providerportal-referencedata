using Dfc.ProviderPortal.ReferenceData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IApprenticeshipStandardService
    {
        Task<IEnumerable<ApprenticeshipStandard>> GetAllAsync();

        Task<IEnumerable<ApprenticeshipStandard>> GetApprenticeshipStandardByStandardCodeAsync(int standardCode);

        Task<ApprenticeshipStandard> GetApprenticeshipStandardByStandardCodeAndVersionAsync(int standardCode, int version);
    }
}