using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Interfaces
{
    public interface ICosmosDbHelper
    {
        Task<Database> CreateDatabaseIfNotExistsAsync(DocumentClient client);

        Task<Document> CreateDocumentAsync(DocumentClient client, string collectionId, object document);

        Task<DocumentCollection> CreateDocumentCollectionIfNotExistsAsync(DocumentClient client, string collectionId);

        IEnumerable<T> DocumentsTo<T>(IEnumerable<Document> documents);

        T DocumentTo<T>(Document document);

        DocumentClient GetClient();

        Document GetDocumentById<T>(DocumentClient client, string collectionId, T id);
    }
}