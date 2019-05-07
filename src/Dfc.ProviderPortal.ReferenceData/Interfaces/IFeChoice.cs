using System;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface IFeChoice
    {
        Guid Id { get; }
        int UPIN { get; }
        decimal LearnerSatisfaction { get; }
        decimal EmployerSatisfaction { get; }
        DateTime? CreatedDateTimeUtc { get; }
    }
}