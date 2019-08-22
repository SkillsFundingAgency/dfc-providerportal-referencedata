using Dfc.ProviderPortal.ReferenceData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IFeChoiceService
    {
        Task<IEnumerable<FeChoice>> GetAllAsync();

        Task<FeChoice> GetByUKPRNAsync(int ukprn);
    }
}