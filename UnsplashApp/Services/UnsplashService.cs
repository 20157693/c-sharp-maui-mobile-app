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
        }

        /* This sends a request to Unsplash with provided
        query and returns the JSON while programs runs in
        parallel. */
        // public for accessibility
        // Async to continue to run while request is pending
        public async Task<string> SearchPhotosAsync(string query)
        {
            string url = "https://api.unsplash.com/search/photos?query="
                + Uri.EscapeDataString(query);

            string accessKey = "vim6b-zXPhN6ZrmJi4t7U6cqNev_G-7KjxUZg-E8tEM";

            // This builds the API request from the query
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Client-ID", accessKey);

            string response = await _httpClient.GetStringAsync(url);

            return response;
        }
    }
}
