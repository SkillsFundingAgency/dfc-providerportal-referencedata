using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IApprenticeshipFramework
    {
        Guid Id { get; }
        int FrameworkCode { get; }
        int ProgType { get; }
        int PathwayCode { get; }
        string PathwayName { get; }
        string NasTitle { get; }
        DateTime? EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }
        decimal SectorSubjectAreaTier1 { get; }
        decimal SectorSubjectAreaTier2 { get; }
        DateTime? CreatedDateTiemUtc { get; }
        DateTime? ModifiedDateTiemUtc { get; }
        int RecordStatusId { get; }
    }
}
