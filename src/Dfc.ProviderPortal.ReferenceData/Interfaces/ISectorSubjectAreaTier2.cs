using System;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface ISectorSubjectAreaTier2
    {
        Guid Id { get; }
        decimal SectorSubjectAreaTier2Id { get; }
        string SectorSubjectAreaTier2Desc { get; }
        string SectorSubjectAreaTier2Desc2 { get; }
        DateTime? EffectiveFrom { get; }
        DateTime? CreatedDateTimeUtc { get; }
        DateTime? ModifiedDateTimeUtc { get; }
    }
}