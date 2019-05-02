using Dfc.ProviderPortal.ReferenceData.Interfaces;
using System;

namespace Dfc.ProviderPortal.ReferenceData.Models
{
    public class StandardSectorCode : IStandardSectorCode
    {
        public Guid Id { get; set; }
        public int StandardSectorCodeId { get; set; }
        public string StandardSectorCodeDesc { get; set; }
        public string StandardSectorCodeDesc2 { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? ModifiedDateTimeUtc { get; set; }
    }
}