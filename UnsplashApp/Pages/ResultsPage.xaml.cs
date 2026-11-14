// Import the SearchResult class
using UnsplashApp.Models;

namespace UnsplashApp.Pages;
// IQueryAttributable: receive the data from the previous page
public partial class ResultsPage : ContentPage, IQueryAttributable
{
	public ResultsPage()
	{
		InitializeComponent();
	}
	// Handles all received data as a dictionary,
	// with keys:values, navigation-name:local-name.
	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if (query.TryGetValue("SearchResult", out object? value)
			// Create local variable for imported SearchResult: result
			&& value is SearchResult result)
		{
			int total = result.Total;
			int count = result.Results?.Count ?? 0;

			ResultsLabel.Text = $"Total: {total}. Received: {count}.";
			// Send this to the CollectionView
			PhotosCollection.ItemsSource = result.Results;
		}
	}

	private async void OnPhotoSelected(
		object sender,
		// Trigger Selection Event on click called 'e'
		SelectionChangedEventArgs e)
	{
		// if currently-selected photo is of type Photo, create selectedPhoto var
		if (e.CurrentSelection.FirstOrDefault() is Photo selectedPhoto)
		{
			// Display pop-up telling you the image is selected
			await DisplayAlertAsync(
				"Photograph selected",
				selectedPhoto.AltDescription ?? "No Description",
				// OK message to close pop-up
				"OK");
		}
	}
}