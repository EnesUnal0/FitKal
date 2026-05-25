using fitkal; // MainPage ana dizinde olduðu için bu satýrý eklemeliyiz

namespace fitkal.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnGirisClicked(object sender, EventArgs e)
    {
        // Kullanýcý rastgele bilgi doldursa bile direkt ana sayfaya geçmesi için:
        await Navigation.PushAsync(new MainPage());

        Console.WriteLine("Giriþ yapýldý, MainPage'e yönlendiriliyor...");
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