using Dfc.ProviderPortal.ReferenceData.Interfaces;

namespace Dfc.ProviderPortal.ReferenceData.Settings
{
    public class CosmosDbCollectionSettings : ICosmosDbCollectionSettings
    {
        public string FeChoicesCollectionId { get; set; }
        public string FrameworksCollectionId { get; set; }
        public string ProgTypesCollectionId { get; set; }
        public string SectorSubjectAreaTier1sCollectionId { get; set; }
        public string SectorSubjectAreaTier2sCollectionId { get; set; }
        public string StandardsCollectionId { get; set; }
        public string StandardSectorCodesCollectionId { get; set; }
    }
}