using UnsplashApp.Models;

namespace UnsplashApp.Pages;
// We will now receive the passed class Photo as selectedPhoto
public partial class PhotoDetailsPage : ContentPage, IQueryAttributable
{
	public PhotoDetailsPage()
	{
		InitializeComponent();
	}
	// The same as ResultsPage, receive passed class
	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if (query.TryGetValue("SelectedPhoto", out object? value)
			// New variable 'photo' for the large photo
			&& value is Photo photo)
		{
			// Sending the photo's description into a Label
			// (in the XAML)
			PhotoDescription.Text =
				photo.AltDescription ?? "No Description Available.";
			// Grab URL of selected image
			string? imageUrl = photo.Urls?.Regular;

			if (!string.IsNullOrEmpty(imageUrl))
			{
				SelectedPhotoImage.Source =
					// Create a URI from the image's URL
					// Then make the XAML element point to it
					ImageSource.FromUri(new Uri(imageUrl));
			}
		}
	}
}