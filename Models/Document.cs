using System.Text.Json.Serialization;

namespace ZiurTest.Models;

/// <summary>
/// Represents a document from the Ziur API with a code, description, and active status.
/// </summary>
public class Document
{
    /// <summary>
    /// The unique code identifying the document.
    /// </summary>
    [JsonPropertyName("Codigo")]
    public int Code { get; set; }
    /// <summary>
    /// The description of the document.
    /// </summary>
    [JsonPropertyName("Descripcion")]
    public string Description { get; set; } = "";
    /// <summary>
    /// Indicates whether the document is active or not.
    /// </summary>
    [JsonPropertyName("Vactiva")]
    public bool VActive { get; set; }
}