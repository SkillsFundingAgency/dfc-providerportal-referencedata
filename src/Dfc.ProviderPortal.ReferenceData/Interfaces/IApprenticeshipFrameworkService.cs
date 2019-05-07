using Dfc.ProviderPortal.ReferenceData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IApprenticeshipFrameworkService
    {
        Task<IEnumerable<ApprenticeshipFramework>> GetAllAsync();

        Task<IEnumerable<ApprenticeshipFramework>> GetApprenticeshipFrameworkByFrameworkCodeAsync(int frameworkCode);

        Task<IEnumerable<ApprenticeshipFramework>> GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAsync(int frameworkCode, int progTypeId);

        Task<ApprenticeshipFramework> GetApprenticeshipFrameworkByFrameworkCodeAndProgTypeIdAndPathwayCodeAsync(int frameworkCode, int progTypeId, int pathwayCode);
    }
}