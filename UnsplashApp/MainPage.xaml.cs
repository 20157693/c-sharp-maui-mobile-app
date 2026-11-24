// Import Services; the API communicator
using UnsplashApp.Services;
// Import Models; the JSON parsers
using UnsplashApp.Models;
// Import Pages; the navigation pages
using UnsplashApp.Pages;
using UnsplashApp.Controllers;

namespace UnsplashApp
{
    // MainPage inheriting from ContentPage
    public partial class MainPage : ContentPage
    {
        // Instantiate the API communicator
        private readonly UnsplashService _unsplashService = new();
        private readonly UnsplashController _controller;

        public MainPage()
        {
            InitializeComponent();
            _controller = new UnsplashController(_unsplashService);
        }

        private async void LoadCollections()
        {
            try
            {
                // Make API request and parse response into a List of Collections
                List<UnsplashCollection>? collections =
                    await _controller.GetCollectionsAsync();

                CollectionsView.ItemsSource = collections;
            }

            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", ex.Message, "Ok");
            }
        }
        /* On each load of Home Search Page, fetch Collection Batch Size
           from settings, then LoadCollections(), displaying them all. */
        // We must modify OnAppearing() to insert LoadCollections()
        // Maintain 'protected' status of original OnAppearing
        // 'override' it with our new definition
        protected override void OnAppearing()
        {
            // Access super() of MainPage
            base.OnAppearing();
            LoadCollections();
        }

        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            // User input from search bar
            // Nullable string
            string? search = SearchEntry.Text;

            StatusLabel.Text = "Searching Unsplash…";

            try
            {
                // API request for search term and store in result
                SearchResult? result =
                    await _controller.SearchAsync(search);

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
                await Shell.Current.GoToAsync(
                    nameof(ResultsPage),
                    new ShellNavigationQueryParameters
                    {
                        { "SearchResult", result }
                    }
                    );
                /* What GoToAsync does is it jumps from the current
                   execution line to the first line on the page,
                   through the navigator. */
                /* ShellNavigationQueryParameters exports values
                   as we go on, so we make our variables
                   available in that namespace. */
            }

            catch (ArgumentException ex)
            {
                StatusLabel.Text = ex.Message;
            }
            catch (HttpRequestException)
            {
                StatusLabel.Text = "The API request failed.";
            }
        }

        private async void OnCollectionSelected(object sender, SelectionChangedEventArgs e)
        {
            // Save clicked item into a variable
            if (e.CurrentSelection.FirstOrDefault() is UnsplashCollection collection)
            {
                // Clear selection
                CollectionsView.SelectedItem = null;

                try
                {
                    // Send API request to receive group of photos from collection
                    // Store all photos in 'result'
                    SearchResult result =
                        await _controller.GetCollectionPhotosAsync(collection.Id!);

                    await Shell.Current.GoToAsync(
                        nameof(ResultsPage),
                        new ShellNavigationQueryParameters
                        {
                            { "SearchResult", result }
                        }
                    );
                }

                catch (Exception ex)
                {
                    await DisplayAlertAsync("Error", ex.Message, "Ok");
                }
            }
        }
    }
}
