using System;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IProgType
    {
        Guid Id { get; }
        int ProgTypeId { get; }
        string ProgTypeDesc { get; }
        string ProgTypeDesc2 { get; }
        DateTime? EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }
        DateTime? CreatedDateTimeUtc { get; }
        DateTime? ModifiedDateTimeUtc { get; }
    }
}