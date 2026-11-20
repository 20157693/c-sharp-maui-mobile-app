using System.Net.Http;

namespace UnsplashApp.Services
{
    public class UnsplashService
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
        public async Task<string> SearchPhotosAsync(string query)
        {
            // Dig into the computer for the value; else, use 10.
            string perPage = Preferences.Get("ImagesPerPage", "10");

            string url = "https://api.unsplash.com/search/photos?query="
                + Uri.EscapeDataString(query)
                + "&per_page=" + perPage;

            string response = await _httpClient.GetStringAsync(url);

            return response;
        }
        // Send request using Collection Batch Size to get JSON
        public async Task<string> GetCollectionsAsync()
        {
            // Fetch set value for number of collections; else, use 3.
            string perPage = Preferences.Get("CollectionsPerPage", "3");

            string url = "https://api.unsplash.com/collections?per_page="
                + perPage;

            string response = await _httpClient.GetStringAsync(url);

            return response;
        }
    }
}
