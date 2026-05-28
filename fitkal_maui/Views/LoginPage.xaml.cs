using fitkal.Services;

namespace fitkal.Views;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _apiService;
    private bool _otomatikKontrolYapildi = false;

    public LoginPage()
    {
        InitializeComponent();
        _apiService = new ApiService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_otomatikKontrolYapildi)
            return;

        _otomatikKontrolYapildi = true;

        bool beniHatirla = Preferences.Default.Get("remember_me", false);
        var token = await SecureStorage.Default.GetAsync("jwt_token");

        if (beniHatirla && !string.IsNullOrEmpty(token))
        {
            Application.Current.MainPage = new AppShell();
        }
    }

    private async void OnGirisClicked(object sender, EventArgs e)
    {
        string username = EntKullanici.Text ?? string.Empty;
        string password = EntSifre.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Uyarý", "Lütfen kullanýcý adý ve þifrenizi girin.", "Tamam");
            return;
        }

        var btn = (Button)sender;
        btn.IsEnabled = false;
        btn.Text = "GÝRÝÞ YAPILIYOR...";

        bool beniHatirla = ChkBeniHatirla.IsChecked;

        bool isSuccess = await _apiService.LoginAsync(username, password, beniHatirla);

        if (isSuccess)
        {
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlert("Hata", "Kullanýcý adý veya þifre hatalý. Lütfen tekrar deneyin.", "Tamam");

            btn.IsEnabled = true;
            btn.Text = "GÝRÝÞ";
        }
    }

    private async void OnUyeOlClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private void OnBeniHatirlaTapped(object sender, EventArgs e)
    {
        ChkBeniHatirla.IsChecked = !ChkBeniHatirla.IsChecked;
    }

    private async void OnSifremiUnuttumTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Bilgi", "Þifre sýfýrlama ekraný yakýnda eklenecek.", "Tamam");
    }
}