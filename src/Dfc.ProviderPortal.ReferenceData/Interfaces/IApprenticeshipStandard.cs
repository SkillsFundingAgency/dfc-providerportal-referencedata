using System;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IApprenticeshipStandard
    {
        Guid Id { get; }
        int StandardCode { get; }
        int Version { get; }
        string StandardName { get; }
        string StandardSectorCode { get; }
        DateTime? EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }
        string URLLink { get; }
        decimal SectorSubjectAreaTier1 { get; }
        decimal SectorSubjectAreaTier2 { get; }
        DateTime? CreatedDateTiemUtc { get; }
        DateTime? ModifiedDateTiemUtc { get; }
        int RecordStatusId { get; }
        string NotionalEndLevel { get; }
        string OtherBodyApprovalRequired { get; }
    }
}