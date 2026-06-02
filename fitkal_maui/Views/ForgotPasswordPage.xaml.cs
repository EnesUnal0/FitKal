namespace fitkal.Views;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
    }

    private async void OnDegistirClicked(object sender, EventArgs e)
    {
    
        await DisplayAlert("Bilgi", "Þifre deðiþtirme talebiniz alýndý.", "Tamam");

   
        await Navigation.PopAsync();
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
       
        await Navigation.PopAsync();
    }
}