using UnsplashApp.Models;
using UnsplashApp.Services;
using System.Text.Json;

namespace UnsplashApp.Pages;
// We will now receive the passed class Photo as selectedPhoto
public partial class PhotoDetailsPage : ContentPage, IQueryAttributable
{
    private readonly UnsplashService _unsplashService = new();

    public PhotoDetailsPage()
    {
        InitializeComponent();
    }
    // The same as ResultsPage, receive passed class
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("SelectedPhoto", out object? value)
            // New variable 'photo' for the large photo
            && value is Photo photo)
        {
            // Grab URL of selected image
            string? imageUrl = photo.Urls?.Regular;

            if (!string.IsNullOrEmpty(imageUrl))
            {
                SelectedPhotoImage.Source =
                    // Create a URI from the image's URL
                    // Then make the XAML element point to it
                    ImageSource.FromUri(new Uri(imageUrl));
            }

            if (string.IsNullOrEmpty(photo.Id))
                return;

            try
            {
                // Send API request for the image details
                string response =
                    await _unsplashService.GetPhotoDetailsAsync(photo.Id);

                Photo? details =
                    JsonSerializer.Deserialize<Photo>(response);

                if (details == null)
                {
                    return;
                }

                PhotographerLabel.Text =
                    $"Photographer: {details.User?.Name ?? ""}";

                ResolutionLabel.Text =
                    $"Resolution: {details.Width?.ToString() ?? ""} × {details.Height?.ToString() ?? ""} px";

                CameraLabel.Text =
                    $"Camera: {details.Exif?.Make ?? ""} {details.Exif?.Model ?? ""}";

                ShutterLabel.Text =
                    $"Shutter speed: {details.Exif?.ExposureTime ?? ""}";

                ApertureLabel.Text =
                    $"Aperture: {details.Exif?.Aperture ?? ""}";

                IsoLabel.Text =
                    $"ISO: {details.Exif?.Iso?.ToString() ?? ""}";

                FocalLengthLabel.Text =
                    $"Focal length: {details.Exif?.FocalLength ?? ""}";

                LocationLabel.Text =
                    $"Location: {details.Location?.Name ?? ""}";
            }

            catch (HttpRequestException)
            {
                // Keep displaying the photo if request fails
            }
        }
    }
}