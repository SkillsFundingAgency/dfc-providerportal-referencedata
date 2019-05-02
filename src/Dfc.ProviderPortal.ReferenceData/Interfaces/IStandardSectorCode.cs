using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IStandardSectorCode
    {
        Guid Id { get; }
        int StandardSectorCodeId { get; }
        string StandardSectorCodeDesc { get; }
        string StandardSectorCodeDesc2 { get; }
        DateTime? EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }
        DateTime? CreatedDateTimeUtc { get; }
        DateTime? ModifiedDateTimeUtc { get; }
    }
}
