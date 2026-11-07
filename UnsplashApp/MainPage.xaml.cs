namespace UnsplashApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            // Nullable string
            string? search = SearchEntry.Text;

            if (string.IsNullOrWhiteSpace(search))
            {
                StatusLabel.Text = "Please enter a search keyword.";
                return;
            }

            StatusLabel.Text = "You searched for " + search;
        }
    }
}
