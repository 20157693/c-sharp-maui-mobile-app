// Import JSON
using System.Text.Json;
// Import Services
using UnsplashApp.Services;

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

                // Convert JSON into C# object
                using JsonDocument document = JsonDocument.Parse(response);

                int total = document.RootElement.GetProperty("total").GetInt32();

                StatusLabel.Text = "Photographs found: " + total;
            }

            catch (HttpRequestException)
            {
                StatusLabel.Text = "The API request failed.";
            }
        }
    }
}
