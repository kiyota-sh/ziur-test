namespace ZiurTest.Configuration;

/// <summary>
/// Represents the options for configuring the Ziur API connection.
/// </summary>
public class ZiurApiOptions
{
    /// <summary>
    /// The name of the configuration section for Ziur API options.
    /// </summary>
    public const string SectionName = "ZiurApi";
    
    /// <summary>
    /// The base URL of Ziur API.
    /// </summary>
    public string BaseUrl { get; set; } = "";
    /// <summary>
    /// The API token for authenticating with Ziur API.
    /// </summary>
    public string Token { get; set; } = "";
}