// Configure Shell navigation to navigating the pages
using UnsplashApp.Pages;

namespace UnsplashApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            /* Defining the name of our Photos page 
               to later reference it as such. */
            Routing.RegisterRoute(nameof(ResultsPage), typeof(ResultsPage));
        }
    }
}
