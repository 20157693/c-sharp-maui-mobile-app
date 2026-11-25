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

        [JsonPropertyName("width")]
        public int? Width { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("likes")]
        public int? Likes { get; set; }

        [JsonPropertyName("user")]
        public PhotoUser? User { get; set; }

        [JsonPropertyName("exif")]
        public PhotoExif? Exif { get; set; }

        [JsonPropertyName("location")]
        public PhotoLocation? Location { get; set; }
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

    internal class PhotoUser
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    internal class PhotoExif
    {
        [JsonPropertyName("make")]
        public string? Make { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("exposure_time")]
        public string? ExposureTime { get; set; }

        [JsonPropertyName("aperture")]
        public string? Aperture { get; set; }

        [JsonPropertyName("focal_length")]
        public string? FocalLength { get; set; }

        [JsonPropertyName("iso")]
        public int? Iso { get; set; }
    }

    internal class PhotoLocation
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
