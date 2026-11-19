namespace UnsplashApp.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        /* Load previously-saved settings,
           else, default to "Light". */
        AppearancePicker.SelectedItem =
            Preferences.Get("Appearance", "Light");

        ImagesPicker.SelectedItem =
            Preferences.Get("ImagesPerPage", "10");

        CollectionsPicker.SelectedItem =
            Preferences.Get("CollectionsPerPage", "3");
    }

    private void OnAppearanceChanged(object sender, EventArgs e)
    {
        // Save the selected values
        if (AppearancePicker.SelectedItem != null)
            Preferences.Set("Appearance",
                AppearancePicker.SelectedItem.ToString());
    }

    private void OnImagesChanged(object sender, EventArgs e)
    {
        if (ImagesPicker.SelectedItem != null)
            Preferences.Set("ImagesPerPage",
                ImagesPicker.SelectedItem.ToString());
    }

    private void OnCollectionsChanged(object sender, EventArgs e)
    {
        if (CollectionsPicker.SelectedItem != null)
            Preferences.Set("CollectionsPerPage",
                CollectionsPicker.SelectedItem.ToString());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}