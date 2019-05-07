using Dfc.ProviderPortal.ReferenceData.Interfaces;
using System;

namespace Dfc.ProviderPortal.ReferenceData.Models
{
    public class ApprenticeshipStandard : IApprenticeshipStandard
    {
        public Guid Id { get; set; }
        public int StandardCode { get; set; }
        public int Version { get; set; }
        public string StandardName { get; set; }
        public string StandardSectorCode { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string URLLink { get; set; }
        public decimal SectorSubjectAreaTier1 { get; set; }
        public decimal SectorSubjectAreaTier2 { get; set; }
        public DateTime? CreatedDateTiemUtc { get; set; }
        public DateTime? ModifiedDateTiemUtc { get; set; }
        public int RecordStatusId { get; set; }
        public string NotionalEndLevel { get; set; }
        public string OtherBodyApprovalRequired { get; set; }
    }
}