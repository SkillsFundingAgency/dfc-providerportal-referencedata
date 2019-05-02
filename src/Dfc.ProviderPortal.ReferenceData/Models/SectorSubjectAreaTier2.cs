using Dfc.ProviderPortal.ReferenceData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.ProviderPortal.ReferenceData.Models
{
    public class SectorSubjectAreaTier2 : ISectorSubjectAreaTier2
    {
        public Guid Id { get; set; }
        public decimal SectorSubjectAreaTier2Id { get; set; }
        public string SectorSubjectAreaTier2Desc { get; set; }
        public string SectorSubjectAreaTier2Desc2 { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? ModifiedDateTimeUtc { get; set; }
    }
}
