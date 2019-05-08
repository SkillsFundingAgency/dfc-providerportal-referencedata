using Dfc.ProviderPortal.ReferenceData.Interfaces;

namespace Dfc.ProviderPortal.ReferenceData.Settings
{
    public class CosmosDbSettings : ICosmosDbSettings
    {
        public string EndpointUri { get; set; }
        public string PrimaryKey { get; set; }
        public string DatabaseId { get; set; }
    }
}