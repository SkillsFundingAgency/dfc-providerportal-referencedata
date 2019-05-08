namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface ICosmosDbSettings
    {
        string EndpointUri { get; }
        string PrimaryKey { get; }
        string DatabaseId { get; }
    }
}