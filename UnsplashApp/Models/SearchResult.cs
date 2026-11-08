using System.Text.Json.Serialization;

namespace UnsplashApp.Models
{
    // Some of the JSON contents go into here.
    // Pieces of data relating to stats for all received photos.
    // Other pieces of info go into Photo.cs
    internal class SearchResult
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("results")]
        public List<Photo>? Results { get; set; }
    }
}
