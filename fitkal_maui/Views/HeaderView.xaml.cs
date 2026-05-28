namespace fitkal.Views;

public partial class HeaderView : ContentView
{
    // YENÝ: Dinlenebilir bir olay (event) oluþturduk
    public static event EventHandler? MenuyeTiklandi;

    public HeaderView()
    {
        InitializeComponent();
    }

    private void OnHomeTapped(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new MainPage());
    }

    private void OnMenuTapped(object sender, EventArgs e)
    {
        // Týklanýnca ana sayfaya sinyal gönderir
        MenuyeTiklandi?.Invoke(this, EventArgs.Empty);
    }
}