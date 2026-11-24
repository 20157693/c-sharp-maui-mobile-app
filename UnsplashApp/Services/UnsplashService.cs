using System.Net.Http;
// Import JSON
using System.Text.Json;
using UnsplashApp.Models;

namespace UnsplashApp.Services
{
    internal class UnsplashService : IUnsplashService
    {   
        // private for security
        private readonly HttpClient _httpClient;

        public UnsplashService()
        {   
            // API-communicator instantiator
            _httpClient = new HttpClient();
            
            string accessKey = "vim6b-zXPhN6ZrmJi4t7U6cqNev_G-7KjxUZg-E8tEM";

            // This builds the API request from the query
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Client-ID", accessKey);
        }

        /* This sends a request to Unsplash with provided
        query and returns the JSON while programs runs in
        parallel. */
        // public for accessibility
        // Async to continue to run while request is pending
        public async Task<SearchResult?> SearchPhotosAsync(string query)
        {
            // Dig into the computer for the value; else, use 10.
            string perPage = Preferences.Get("ImagesPerPage", "10");

            string url = "https://api.unsplash.com/search/photos?query="
                + Uri.EscapeDataString(query)
                + "&per_page=" + perPage;

            string response = await _httpClient.GetStringAsync(url);

            return JsonSerializer.Deserialize<SearchResult>(response);
        }

        public async Task<Photo?> GetPhotoDetailsAsync(string id)
        {
            string url = "https://api.unsplash.com/photos/" + id;

            string response = await _httpClient.GetStringAsync(url);

            return JsonSerializer.Deserialize<Photo>(response);
        }
        // Send request using Collection Batch Size to get JSON, then parse.
        public async Task<List<UnsplashCollection>?> GetCollectionsAsync()
        {
            // Fetch set value for number of collections; else, use 3.
            string perPage = Preferences.Get("CollectionsPerPage", "3");

            string url = "https://api.unsplash.com/collections?per_page="
                + perPage;

            string response = await _httpClient.GetStringAsync(url);

            return JsonSerializer.Deserialize<List<UnsplashCollection>>(response);
        }

        public async Task<List<Photo>?> GetCollectionPhotosAsync(string id)
        {
            string perPage = Preferences.Get("ImagesPerPage", "10");

            string url = "https://api.unsplash.com/collections/"
                + id + "/photos?per_page=" + perPage;

            // Get JSON array
            string response = await _httpClient.GetStringAsync(url);
            // Parse the JSON into a List of Photos
            return JsonSerializer.Deserialize<List<Photo>>(response);
        }
    }
}
