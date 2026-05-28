namespace fitkal.Views;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
    }

    private async void OnDegistirClicked(object sender, EventArgs e)
    {
        // Þifre deðiþtirme mantýðý buraya gelecek
        // Örn: API isteði gönderilecek
        await DisplayAlert("Bilgi", "Þifre deðiþtirme talebiniz alýndý.", "Tamam");

        // Ýþlem bittikten sonra giriþ sayfasýna geri dönebiliriz
        await Navigation.PopAsync();
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
        // Önceki sayfaya geri döner
        await Navigation.PopAsync();
    }
}