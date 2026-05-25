namespace fitkal.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Kayýt iþlemleri algoritmasý buraya gelecek
        await DisplayAlert("Baþarýlý", "Hesabýnýz oluþturuldu!", "Tamam");

        // Kayýttan sonra giriþ sayfasýna veya ana sayfaya yönlendirebilirsin
        // await Shell.Current.GoToAsync("//LoginPage");
    }

    private async void OnBackToLoginTapped(object sender, EventArgs e)
    {
        // Kullanýcý yanlýþlýkla týkladýysa geri dönmesini saðlar
        await Navigation.PopAsync();
    }
}