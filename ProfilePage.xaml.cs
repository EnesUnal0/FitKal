namespace fitkal;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();

        // Örnek verileri kutucuklara dolduralým
        EntAd.Text = "Enes";
        EntSoyad.Text = "Ünal";
        EntYas.Text = "22";
        EntKilo.Text = "80";
        EntBoy.Text = "180";
        EntHedefKilo.Text = "75";
        EntHedefKalori.Text = "2500";
    }

    private async void OnGuncelleClicked(object sender, EventArgs e)
    {
        // Kutucuklardaki verileri alalým
        string ad = EntAd.Text;
        string hedefKaloriStr = EntHedefKalori.Text;

        if (double.TryParse(hedefKaloriStr, out double yeniHedef))
        {
            // Ana sayfaya (MainPage) yeni hedefi ve ismi "sinyal" olarak gönderiyoruz
            MessagingCenter.Send(this, "UpdateProfile", (ad, yeniHedef));

            await DisplayAlert("Baþarýlý", "Profil bilgileriniz güncellendi!", "Tamam");

            // Güncelleme sonrasý ana sayfaya geri döner
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        else
        {
            await DisplayAlert("Hata", "Lütfen geçerli bir kalori deðeri girin.", "Tamam");
        }
    }
}