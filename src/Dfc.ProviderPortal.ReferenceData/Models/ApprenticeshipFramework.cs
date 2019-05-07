using Dfc.ProviderPortal.ReferenceData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.ProviderPortal.ReferenceData.Models
{
    public class ApprenticeshipFramework : IApprenticeshipFramework
    {
        public Guid Id { get; set; }
        public int FrameworkCode { get; set; }
        public int ProgType { get; set; }
        public int PathwayCode { get; set; }
        public string PathwayName { get; set; }
        public string NasTitle { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public decimal SectorSubjectAreaTier1 { get; set; }
        public decimal SectorSubjectAreaTier2 { get; set; }
        public DateTime? CreatedDateTiemUtc { get; set; }
        public DateTime? ModifiedDateTiemUtc { get; set; }
        public int RecordStatusId { get; set; }
    }
}
