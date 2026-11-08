using System.Text.Json.Serialization;

namespace UnsplashApp.Models
{
    // Some of the JSON contents go into here.
    // Pieces of data relating to Individual Image information.
    // Other pieces of info go into SearchResult.cs
    internal class Photo
    {
        // All variable types Nullable
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("alt_description")]
        public string? AltDescription { get; set; }

        [JsonPropertyName("urls")]
        // Nested classes for nested data structures
        // Urls Nullable
        public PhotoUrls? Urls { get; set; }
    }
    // This class to fit in the above class
    internal class PhotoUrls
    {
        /* The Nullability above accesses 'Regular'
        conditional to it being non-null. */
        [JsonPropertyName("regular")]
        public string? Regular { get; set; }

        [JsonPropertyName("small")]
        public string? Small { get; set; }
    }
}
