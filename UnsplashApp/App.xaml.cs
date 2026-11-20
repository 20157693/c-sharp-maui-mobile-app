using Microsoft.Extensions.DependencyInjection;

namespace UnsplashApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string appearance = Preferences.Get("Appearance", "Light");

            if (appearance == "Dark")
                UserAppTheme = AppTheme.Dark;
            else
                UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}