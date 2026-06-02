namespace fitkal;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

      
        MainPage = new NavigationPage(new fitkal.Views.LoginPage());
    }
}