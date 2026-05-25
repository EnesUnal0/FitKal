namespace fitkal;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Uygulama ilk açıldığında Views altındaki LoginPage'i bir navigasyon zinciriyle başlatır
        MainPage = new NavigationPage(new fitkal.Views.LoginPage());
    }
}