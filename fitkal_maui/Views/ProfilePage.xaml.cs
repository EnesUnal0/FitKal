using fitkal.Services;

namespace fitkal.Views;

public partial class ProfilePage : ContentPage
{
    private readonly ApiService _apiService;

    public ProfilePage()
    {
        InitializeComponent();
        _apiService = new ApiService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ProfiliYukle();
    }

    private async Task ProfiliYukle()
    {
        var profil = await _apiService.GetProfileAsync();

        if (profil != null)
        {
            EntAd.Text = profil.Name;
            EntSoyad.Text = profil.Surname;

            if (profil.BirthDate.HasValue)
            {
                DpDogumTarihi.Date = profil.BirthDate.Value;
            }

            EntBoy.Text = profil.Height?.ToString();
            EntKilo.Text = profil.Weight?.ToString();
            EntHedefKilo.Text = profil.TargetWeight?.ToString();
            EntHedefKalori.Text = profil.GoalCalories?.ToString();

            if (profil.ActivityLevel.HasValue)
            {
                PickerAktiviteSeviyesi.SelectedIndex = profil.ActivityLevel.Value;
            }
            else
            {
                PickerAktiviteSeviyesi.SelectedIndex = -1;
            }

            string gorunenAd = !string.IsNullOrWhiteSpace(profil.Name)
                ? profil.Name
                : !string.IsNullOrWhiteSpace(profil.Username)
                    ? profil.Username
                    : "Kullanýcý";

            LblAdSoyadUst.Text = gorunenAd;

            string guncelKilo = profil.Weight.HasValue
                ? profil.Weight.Value.ToString()
                : "--";

            string guncelBoy = profil.Height.HasValue
                ? profil.Height.Value.ToString()
                : "--";

            LblAltBilgi.Text = $"{guncelKilo} kg, {guncelBoy} cm";

            if (profil.TargetWeight.HasValue)
                LblHedefKiloUst.Text = $"Hedef Kg : {profil.TargetWeight.Value}";
            else
                LblHedefKiloUst.Text = "Hedef Kg : --";
        }
    }

    private async void OnGuncelleClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        btn.IsEnabled = false;
        btn.Text = "GÜNCELLENÝYOR...";

        try
        {
            double? boy = double.TryParse(EntBoy.Text, out double b)
                ? b
                : null;

            double? kilo = double.TryParse(EntKilo.Text, out double k)
                ? k
                : null;

            double? hedefKilo = double.TryParse(EntHedefKilo.Text, out double hk)
                ? hk
                : null;

            int? kalori = int.TryParse(EntHedefKalori.Text, out int c)
                ? c
                : null;

            DateTime? dogumTarihi = DpDogumTarihi.Date;

            int? aktiviteSeviyesi = PickerAktiviteSeviyesi.SelectedIndex >= 0
                ? PickerAktiviteSeviyesi.SelectedIndex
                : null;

            var guncelVeri = new UserProfile
            {
                Name = EntAd.Text,
                Surname = EntSoyad.Text,
                BirthDate = dogumTarihi,

                Height = boy,
                Weight = kilo,
                TargetWeight = hedefKilo,
                GoalCalories = kalori,

                Gender = "Belirtilmemiþ",
                ActivityLevel = aktiviteSeviyesi
            };

            bool basariliMi = await _apiService.UpdateProfileAsync(guncelVeri);

            if (basariliMi)
            {
                await DisplayAlert("Baþarýlý", "Profil bilgileriniz güncellendi.", "Tamam");

                string gorunenAd = !string.IsNullOrWhiteSpace(EntAd.Text)
                    ? EntAd.Text
                    : "Kullanýcý";

                LblAdSoyadUst.Text = gorunenAd;

                string guncelKiloStr = kilo.HasValue
                    ? kilo.Value.ToString()
                    : "--";

                string guncelBoyStr = boy.HasValue
                    ? boy.Value.ToString()
                    : "--";

                LblAltBilgi.Text = $"{guncelKiloStr} kg, {guncelBoyStr} cm";

                if (hedefKilo.HasValue)
                    LblHedefKiloUst.Text = $"Hedef Kg : {hedefKilo.Value}";
                else
                    LblHedefKiloUst.Text = "Hedef Kg : --";
            }
            else
            {
                await DisplayAlert("Hata", "Bilgiler güncellenirken bir sorun oluþtu.", "Tamam");
            }
        }
        finally
        {
            btn.IsEnabled = true;
            btn.Text = "GÜNCELLE";
        }
    }

    private void OnSifrePenceresiAcClicked(object sender, EventArgs e)
    {
        SifrePopup.IsVisible = true;
    }

    private void OnSifrePenceresiKapatClicked(object sender, EventArgs e)
    {
        SifrePopup.IsVisible = false;
        SifreAlanlariniTemizle();
    }

    private async void OnSifreGuncelleClicked(object sender, EventArgs e)
    {
        string username = EntSifreKullaniciAdi.Text?.Trim() ?? string.Empty;
        string eskiSifre = EntEskiSifre.Text ?? string.Empty;
        string yeniSifre = EntYeniSifre.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(eskiSifre) ||
            string.IsNullOrWhiteSpace(yeniSifre))
        {
            await DisplayAlert("Uyarý", "Lütfen kullanýcý adý, eski þifre ve yeni þifre alanlarýný doldurun.", "Tamam");
            return;
        }

        if (yeniSifre.Length < 5)
        {
            await DisplayAlert("Uyarý", "Yeni þifre en az 5 karakter olmalýdýr.", "Tamam");
            return;
        }

        bool basariliMi = await _apiService.ChangePasswordAsync(username, eskiSifre, yeniSifre);

        if (basariliMi)
        {
            await DisplayAlert("Baþarýlý", "Þifreniz baþarýyla güncellendi.", "Tamam");

            SifrePopup.IsVisible = false;
            SifreAlanlariniTemizle();
        }
        else
        {
            await DisplayAlert("Hata", "Kullanýcý adý veya eski þifre hatalý.", "Tamam");
        }
    }

    private void SifreAlanlariniTemizle()
    {
        EntSifreKullaniciAdi.Text = string.Empty;
        EntEskiSifre.Text = string.Empty;
        EntYeniSifre.Text = string.Empty;
    }
}