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

    // --- SAYFA AÇILDIÐINDA ÇALIÞIR ---
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ProfiliYukle();
    }

    // --- API'DEN VERÝLERÝ ÇEKÝP KUTULARA VE ÜST BÝLGÝLERE DOLDURUR ---
    private async Task ProfiliYukle()
    {
        var profil = await _apiService.GetProfileAsync();

        if (profil != null)
        {
            // Kutularý Doldurma
            // Not: Backend modelinde (UserProfile) Ad, Soyad, Doðum Tarihi, Hedef Kilo ve Aktivite 
            // alanlarý olmadýðý için o kutularý sadece görsel olarak tutuyoruz, veritabanýndan çekemiyoruz.
            EntBoy.Text = profil.Height?.ToString();
            EntKilo.Text = profil.Weight?.ToString();
            EntHedefKalori.Text = profil.GoalCalories?.ToString();

            // Üst kýsýmdaki dinamik etiketleri güncelleme
            LblAdSoyadUst.Text = profil.Username ?? "Kullanýcý";

            string guncelKilo = profil.Weight.HasValue ? profil.Weight.Value.ToString() : "--";
            string guncelBoy = profil.Height.HasValue ? profil.Height.Value.ToString() : "--";
            LblAltBilgi.Text = $"{guncelKilo} kg, {guncelBoy} cm";
        }
    }

    // --- GÜNCELLE BUTONUNA TIKLANDIÐINDA ÇALIÞIR ---
    private async void OnGuncelleClicked(object sender, EventArgs e)
    {
        // Butonu geçici olarak kilitle (kullanýcý üst üste basmasýn diye)
        var btn = (Button)sender;
        btn.IsEnabled = false;
        btn.Text = "GÜNCELLENÝYOR...";

        // Kullanýcýnýn girdiði metinleri sayýsal deðerlere dönüþtür
        double? boy = double.TryParse(EntBoy.Text, out double b) ? b : null;
        double? kilo = double.TryParse(EntKilo.Text, out double k) ? k : null;
        int? kalori = int.TryParse(EntHedefKalori.Text, out int c) ? c : null;

        // PckAktivite, DpDogumTarihi, EntAd, EntSoyad, EntHedefKilo gibi alanlar
        // þu anki backend (UserProfile) modelinde olmadýðý için onlarý API'ye gönderemiyoruz.
        // Ýleride backend'e bu alanlar eklenirse buraya dahil edeceðiz.

        // Gönderilecek paketi hazýrla (Þimdilik backend'in desteklediði alanlar)
        var guncelVeri = new UserProfile
        {
            Height = boy,
            Weight = kilo,
            GoalCalories = kalori,
            Gender = "Belirtilmemiþ" // Backend modelinde var ama tasarýmda yok, varsayýlan atýyoruz
        };

        // Kuryeyi API'ye gönder
        bool basariliMi = await _apiService.UpdateProfileAsync(guncelVeri);

        if (basariliMi)
        {
            await DisplayAlert("Baþarýlý", "Profil bilgileriniz güncellendi.", "Tamam");

            // Baþarýlý olursa üstteki etiketleri de hemen güncelle
            string guncelKiloStr = kilo.HasValue ? kilo.Value.ToString() : "--";
            string guncelBoyStr = boy.HasValue ? boy.Value.ToString() : "--";
            LblAltBilgi.Text = $"{guncelKiloStr} kg, {guncelBoyStr} cm";
            LblHedefKiloUst.Text = $"Hedef Kg : {EntHedefKilo.Text}";
        }
        else
        {
            await DisplayAlert("Hata", "Bilgiler güncellenirken bir sorun oluþtu.", "Tamam");
        }

        // Ýþlem bitince butonu eski haline getir
        btn.IsEnabled = true;
        btn.Text = "GÜNCELLE";
    }
}