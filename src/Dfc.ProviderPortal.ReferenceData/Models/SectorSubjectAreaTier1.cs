using Dfc.ProviderPortal.ReferenceData.Interfaces;
using System;

namespace Dfc.ProviderPortal.ReferenceData.Models
{
    public class SectorSubjectAreaTier1 : ISectorSubjectAreaTier1
    {
        public Guid Id { get; set; }
        public decimal SectorSubjectAreaTier1Id { get; set; }
        public string SectorSubjectAreaTier1Desc { get; set; }
        public string SectorSubjectAreaTier1Desc2 { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? ModifiedDateTimeUtc { get; set; }
    }
}