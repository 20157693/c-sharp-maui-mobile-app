using System.Text.Json.Serialization;

namespace UnsplashApp.Models;

internal class UnsplashCollection
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("cover_photo")]
    public Photo? CoverPhoto { get; set; }
}