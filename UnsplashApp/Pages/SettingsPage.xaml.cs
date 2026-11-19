namespace UnsplashApp.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	private async void OnHomeClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}
}