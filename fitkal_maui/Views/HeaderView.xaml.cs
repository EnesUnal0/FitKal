namespace fitkal.Views;

public partial class HeaderView : ContentView
{
    // MainPage'in beklediði o habercimiz (Event)
    public event EventHandler MenuTiklandi;

    public HeaderView()
    {
        InitializeComponent();
    }

    // Menü ikonuna týklandýðýnda çalýþacak metot
    private void OnMenuIconTapped(object sender, TappedEventArgs e)
    {
        // Ýkona týklandýðýnda MainPage'e "Menüye týklandý, aç!" sinyalini ateþler
        MenuTiklandi?.Invoke(this, EventArgs.Empty);
    }

    // Senin tasarýmýndaki "Ana Sayfaya Dön" ikonuna/logosuna týklandýðýnda çalýþacak metot
    private async void OnHomeTapped(object sender, TappedEventArgs e)
    {
        // Kullanýcýyý AppShell üzerindeki ana sayfaya yönlendirir
        await Shell.Current.GoToAsync("//MainPage");
    }
}