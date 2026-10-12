using ZiurTest.Models;

public interface IDocumentService
{
    /// <summary>
    /// Retrieves a list of documents from the Ziur API.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of documents.</returns>
    Task<IReadOnlyList<Document>> GetDocumentsAsync(CancellationToken cancellationToken = default);
}