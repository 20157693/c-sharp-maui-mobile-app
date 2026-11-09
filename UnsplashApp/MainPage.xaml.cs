// Import JSON
using System.Text.Json;
// Import Services; the API communicator
using UnsplashApp.Services;
// Import Models; the JSON parsers
using UnsplashApp.Models;
// Import Pages; the navigation pages
using UnsplashApp.Pages;

namespace UnsplashApp
{
    public partial class MainPage : ContentPage
    {
        // Instantiate the API communicator
        private readonly UnsplashService _unsplashService = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            // User input from search bar
            // Nullable string
            string? search = SearchEntry.Text;

            if (string.IsNullOrWhiteSpace(search))
            {
                StatusLabel.Text = "Please enter a search keyword.";
                return;
            }

            StatusLabel.Text = "Searching Unsplash…";

            try
            {
                string response = await _unsplashService.SearchPhotosAsync(search);

                /* 'result' is a variable containing class 'SearchResult'
                    into which JSON has been parsed and distributed into
                    its fields. */
                // 'result' is the partially parsed JSON.
                SearchResult? result = JsonSerializer.Deserialize<SearchResult>(response);

                if (result == null)
                {
                    StatusLabel.Text = "Could not read the response.";
                    return;
                }
                // Total photographs matching query
                int total = result.Total;
                // Number of items in list of photos
                // Total photographs in batch received
                int count = result.Results?.Count ?? 0;

                StatusLabel.Text = $"Photographs found: {total}. Received: {count}.";
                /* Order current Shell open 'ResultsPage'
                   after passing through all processing and
                   handling exceptions. */
                // Async + Await ≈ Sequential
                await Shell.Current.GoToAsync(nameof(ResultsPage));
            }

            catch (HttpRequestException)
            {
                StatusLabel.Text = "The API request failed.";
            }
        }
    }
}
