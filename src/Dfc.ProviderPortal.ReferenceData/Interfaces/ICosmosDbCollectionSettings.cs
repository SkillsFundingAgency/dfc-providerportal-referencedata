namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface ICosmosDbCollectionSettings
    {
        string FeChoicesCollectionId { get; }
        string FrameworksCollectionId { get; }
        string ProgTypesCollectionId { get; }
        string SectorSubjectAreaTier1sCollectionId { get; }
        string SectorSubjectAreaTier2sCollectionId { get; }
        string StandardsCollectionId { get; }
        string StandardSectorCodesCollectionId { get; }
    }
}