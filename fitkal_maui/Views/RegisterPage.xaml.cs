using fitkal.Services;

namespace fitkal.Views;

public partial class RegisterPage : ContentPage
{
    // Kuryemizi hazýrlýyoruz
    private readonly ApiService _apiService;

    public RegisterPage()
    {
        InitializeComponent();
        _apiService = new ApiService();
    }

    // ÜYE OL BUTONU TIKLANDIÐINDA
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // 1. Kutulardaki yazýlarý al
        string email = EntEposta.Text;
        string username = EntKullaniciAdi.Text;
        string password = EntSifre.Text;

        // 2. Boþluk kontrolü yap
        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Uyarý", "Lütfen tüm alanlarý doldurun.", "Tamam");
            return;
        }

        // Kullanýcýnýn beklemesi için butonu pasif yapalým
        var btn = (Button)sender;
        btn.IsEnabled = false;
        btn.Text = "KAYIT YAPILIYOR...";

        // 3. API'ye kayýt isteðini gönder
        bool isSuccess = await _apiService.RegisterAsync(username, email, password);

        if (isSuccess)
        {
            // Kayýt baþarýlýysa kullanýcýya bilgi ver ve Login sayfasýna geri dön
            await DisplayAlert("Baþarýlý", "Hesabýnýz oluþturuldu. Þimdi giriþ yapabilirsiniz.", "Tamam");
            await Navigation.PopAsync();
        }
        else
        {
            // Hata olursa uyarý ver ve butonu eski haline getir
            await DisplayAlert("Hata", "Kayýt oluþturulamadý. Bu e-posta veya kullanýcý adý zaten kullanýmda olabilir.", "Tamam");
            btn.IsEnabled = true;
            btn.Text = "ÜYE OL";
        }
    }

    // ZATEN ÜYE MÝSÝNÝZ? (GÝRÝÞ YAP) YAZISINA TIKLANDIÐINDA
    private async void OnBackToLoginTapped(object sender, EventArgs e)
    {
        // Bulunduðumuz Kayýt Ol sayfasýný kapatýp bir önceki (Login) sayfasýna döner
        await Navigation.PopAsync();
    }
}