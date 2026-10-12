using ZiurTest.Models;

namespace ZiurTest.Extensions;

public static class DocumentQueryExtensions
{
    public static IEnumerable<Document> Search(this IEnumerable<Document> source, string? term)
    {
        if (string.IsNullOrWhiteSpace(term))
            return source;

        var t = term.Trim();

        return source.Where(d =>
            d.Code.ToString().Contains(t, StringComparison.Ordinal) ||
            d.Description.Contains(t, StringComparison.OrdinalIgnoreCase));
    }

    public static IEnumerable<Document> OrderByColumn(
        this IEnumerable<Document> source, DocumentColumn column, bool ascending) =>
        column switch
        {
            DocumentColumn.Code => ascending
                ? source.OrderBy(d => d.Code)
                : source.OrderByDescending(d => d.Code),

            DocumentColumn.Description => ascending
                ? source.OrderBy(d => d.Description, StringComparer.OrdinalIgnoreCase)
                : source.OrderByDescending(d => d.Description, StringComparer.OrdinalIgnoreCase),

            DocumentColumn.VActive => ascending
                ? source.OrderBy(d => d.VActive)
                : source.OrderByDescending(d => d.VActive),

            _ => source
        };
}