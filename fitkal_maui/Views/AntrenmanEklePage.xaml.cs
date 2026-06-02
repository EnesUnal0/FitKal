using fitkal.Services;

namespace fitkal.Views;

public class Egzersiz
{
    public string Ad { get; set; } = string.Empty;

 
    public double SaatlikKalori { get; set; }
}

public partial class AntrenmanEklePage : ContentPage
{
    private readonly ApiService _apiService;

    private readonly List<Egzersiz> tumEgzersizler = new List<Egzersiz>
    {
        new Egzersiz { Ad = "Koþu (Orta Tempo)", SaatlikKalori = 600 },
        new Egzersiz { Ad = "Aðýrlýk Antrenmaný", SaatlikKalori = 300 },
        new Egzersiz { Ad = "Bisiklet Sürmek", SaatlikKalori = 500 },
        new Egzersiz { Ad = "Yüzme", SaatlikKalori = 450 },
        new Egzersiz { Ad = "Yürüyüþ (Hafif Tempo)", SaatlikKalori = 250 }
    };

    private Egzersiz? secilenEgzersiz;

    public AntrenmanEklePage()
    {
        InitializeComponent();

        _apiService = new ApiService();

        EgzersizListesi.ItemsSource = tumEgzersizler;
    }

    private async void OnGeriTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnAramaDegisti(object sender, TextChangedEventArgs e)
    {
        string aranan = e.NewTextValue?.ToLower() ?? string.Empty;

        EgzersizListesi.ItemsSource = tumEgzersizler
            .Where(x => x.Ad.ToLower().Contains(aranan))
            .ToList();
    }

    private void OnEgzersizSecildi(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Egzersiz secilen)
        {
            secilenEgzersiz = secilen;

            LblSecilenEgzersiz.Text = secilen.Ad;
            LblSaatlikKalori.Text = $"{secilen.SaatlikKalori:F0} cal";

            EntDakika.Text = string.Empty;
            HesaplamaPaneli.IsVisible = true;
        }
    }

    private async void OnAntrenmanEkleClicked(object sender, EventArgs e)
    {
        if (secilenEgzersiz == null)
        {
            await DisplayAlert("Hata", "Lütfen bir antrenman seçiniz.", "Tamam");
            return;
        }

        if (!double.TryParse(EntDakika.Text, out double dakika) || dakika <= 0)
        {
            await DisplayAlert("Hata", "Lütfen geçerli bir dakika giriniz.", "Tamam");
            return;
        }

        double oran = dakika / 60.0;
        double yakilanKalori = secilenEgzersiz.SaatlikKalori * oran;

        bool basariliMi = await _apiService.AddExerciseAsync(
            secilenEgzersiz.Ad,
            dakika,
            yakilanKalori
        );

        if (basariliMi)
        {
            await DisplayAlert(
                "Tebrikler!",
                $"{dakika:F0} dakika {secilenEgzersiz.Ad} yaparak {Math.Round(yakilanKalori, 1)} kalori yaktýnýz.",
                "Tamam"
            );

            EgzersizListesi.SelectedItem = null;
            HesaplamaPaneli.IsVisible = false;

            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert(
                "Hata",
                "Antrenman veritabanýna kaydedilemedi. API baðlantýsýný kontrol edin.",
                "Tamam"
            );
        }
    }
}