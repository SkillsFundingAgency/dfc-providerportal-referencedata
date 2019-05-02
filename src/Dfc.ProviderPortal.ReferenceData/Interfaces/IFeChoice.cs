using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IFeChoice
    {
        Guid Id { get; }
        int UPIN { get; }
        double LearnerSatisfaction { get; }
        double EmployerSatisfaction { get; }
        DateTime? CreatedDateTimeUtc { get; }
    }
}
