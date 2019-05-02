using Dfc.ProviderPortal.ReferenceData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.ProviderPortal.ReferenceData.Models
{
    public class FeChoice : IFeChoice
    {
        public Guid Id { get; set; }
        public int UPIN { get; set; }
        public double LearnerSatisfaction { get; set; }
        public double EmployerSatisfaction { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
    }
}
