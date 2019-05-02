using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface ISectorSubjectAreaTier1
    {
        Guid Id { get; }
        decimal SectorSubjectAreaTier1Id { get; }
        string SectorSubjectAreaTier1Desc { get; }
        string SectorSubjectAreaTier1Desc2 { get; }
        DateTime? EffectiveFrom { get; }
        DateTime? CreatedDateTimeUtc { get; }
        DateTime? ModifiedDateTimeUtc { get; }
    }
}
