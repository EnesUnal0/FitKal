using fitkal; // MainPage ana dizinde olduðu için bu satýrý eklemeliyiz

namespace fitkal.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    // YENÝ EKLENEN (18. Madde): "Beni Hatýrla" yazýsýna týklanýnca kutucuðu iþaretler/kaldýrýr
    private void OnBeniHatirlaTapped(object sender, EventArgs e)
    {
        ChkBeniHatirla.IsChecked = !ChkBeniHatirla.IsChecked;
    }

    private async void OnGirisClicked(object sender, EventArgs e)
    {
        // YENÝ EKLENEN (23. Madde): Form veri doðrulamasý (Boþ býrakýlamaz kontrolü)
        string kullanici = EntKullanici.Text;
        string sifre = EntSifre.Text;

        if (string.IsNullOrWhiteSpace(kullanici) || string.IsNullOrWhiteSpace(sifre))
        {
            await DisplayAlert("Uyarý", "Lütfen kullanýcý adý ve þifrenizi giriniz.", "Tamam");
            return; // Kodun buradan aþaðý devam edip ana sayfayý açmasýný engeller
        }

        // (Ýsteðe baðlý) Ýleride veritabanýna baðlarken Checkbox'ýn durumunu böyle okuyabilirsin
        bool beniHatirla = ChkBeniHatirla.IsChecked;

        // Senin mevcut yönlendirme kodun:
        await Navigation.PushAsync(new MainPage());

        Console.WriteLine($"Giriþ yapýldý, MainPage'e yönlendiriliyor... (Beni Hatýrla: {beniHatirla})");
    }

    private async void OnUyeOlClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private async void OnSifremiUnuttumTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgotPasswordPage());
    }
}