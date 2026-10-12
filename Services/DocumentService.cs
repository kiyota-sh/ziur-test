using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using ZiurTest.Configuration;

public class DocumentService : IDocumentService
{
    private readonly HttpClient _http;
    private readonly ZiurApiOptions _options;
    private readonly ILogger<DocumentService> _logger;

    public DocumentService(HttpClient http, IOptions<ZiurApiOptions> options, ILogger<DocumentService> logger)
    {
        _http = http;
        _options = options.Value;
        _logger = logger;
    }

    public async Task<IReadOnlyList<Document>> GetDocumentsAsync(CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(_options.BaseUrl) || string.IsNullOrWhiteSpace(_options.Token))
            throw new Exception("Ziur API options are not properly configured. Please check configuration settings.");

        using var request = new HttpRequestMessage(HttpMethod.Get, _options.BaseUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.Token);

        try
        {
            using var response = await _http.SendAsync(request, cancellationToken);

            if (response.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
                throw new UnauthorizedAccessException("Unauthorized access to Ziur API.");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error fetching documents from Ziur API. Status code: {(int)response.StatusCode}");

            var data = await response.Content.ReadFromJsonAsync<List<Document>>(cancellationToken);
            return data ?? [];
        }
        catch (TaskCanceledException)
        {
            throw new OperationCanceledException("The request to Ziur API was canceled.");
        }

    }
}