using Microsoft.AspNetCore.Components;
using ZiurTest.Extensions;
using ZiurTest.Models;

namespace ZiurTest.Components.Pages;

public partial class Documents : IDisposable
{
    [Inject] private IDocumentService Service { get; set; } = default!;
    [Inject] private ILogger<Documents> Logger { get; set; } = default!;

    private readonly CancellationTokenSource _cts = new();

    private List<Document> _documents = new();
    private List<Document> _visibleDocuments = new();

    private string _searchTerm = "";
    private DocumentColumn _sortColumn = DocumentColumn.Code;
    private bool _ascending = true;

    private bool _isLoading = true;
    private string? _errorMessage;

    private string EmptyMessage => _documents.Count == 0
        ? "API returned no documents."
        : "No documents match the search criteria.";

    protected override async Task OnInitializedAsync()
    {
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        _isLoading = true;
        _errorMessage = null;
        StateHasChanged();

        try
        {
            var result = await Service.GetDocumentsAsync(_cts.Token);
            _documents = result?.ToList() ?? new List<Document>();
            UpdateView();
        }
        catch (OperationCanceledException)
        {
            return;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Unexpected error occurred while loading documents.");
            _errorMessage = "Unexpected error occurred while loading documents. Please try again later.";
            _documents = new List<Document>();
            _visibleDocuments = new List<Document>();            
        }
        finally
        {
            _isLoading = false;
            StateHasChanged();
        }
    }

    private void UpdateView()
    {
        if (_documents == null || _documents.Count == 0)
        {
            _visibleDocuments = new List<Document>();
            return;
        }
        
        _visibleDocuments = _documents
            .Search(_searchTerm)
            .OrderByColumn(_sortColumn, _ascending)
            .ToList();
    }

    private void OnSortRequested(DocumentColumn column)
    {
        if (_sortColumn == column)
        {
            _ascending = !_ascending;
        }
        else
        {
            _sortColumn = column;
            _ascending = true;
        }

        UpdateView();
    }

    private void ClearSearch()
    {
        _searchTerm = "";
        UpdateView();
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}