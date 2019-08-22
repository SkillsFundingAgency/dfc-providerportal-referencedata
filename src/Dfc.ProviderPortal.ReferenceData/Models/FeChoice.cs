using Dfc.ProviderPortal.ReferenceData.Interfaces;
using System;

namespace Dfc.ProviderPortal.ReferenceData.Models
{
    public class FeChoice : IFeChoice
    {
        public Guid Id { get; set; }
        public int UKPRN { get; set; }
        public decimal LearnerSatisfaction { get; set; }
        public decimal EmployerSatisfaction { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
    }
}