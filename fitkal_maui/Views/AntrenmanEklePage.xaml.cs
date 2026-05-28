namespace fitkal.Views;

// Egzersiz modelimiz
public class Egzersiz
{
    public string Ad { get; set; }
    public double SaatlikKalori { get; set; } // 60 dakikada yakýlan ortalama kalori
}

public partial class AntrenmanEklePage : ContentPage
{
    // Veritabaný yerine kullanacaðýmýz liste (Daha sonra DB'den gelecek)
    List<Egzersiz> tumEgzersizler = new List<Egzersiz>
    {
        new Egzersiz { Ad = "Koþu (Orta Tempo)", SaatlikKalori = 600 },
        new Egzersiz { Ad = "Aðýrlýk Antrenmaný", SaatlikKalori = 300 },
        new Egzersiz { Ad = "Bisiklet Sürmek", SaatlikKalori = 500 },
        new Egzersiz { Ad = "Yüzme", SaatlikKalori = 450 },
        new Egzersiz { Ad = "Yürüyüþ (Hafif Tempo)", SaatlikKalori = 250 }
    };

    Egzersiz secilenEgzersiz;

    public AntrenmanEklePage()
    {
        InitializeComponent();
        EgzersizListesi.ItemsSource = tumEgzersizler;
    }

    private async void OnGeriTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // Arama Çubuðu Filtrelemesi
    private void OnAramaDegisti(object sender, TextChangedEventArgs e)
    {
        string aranan = e.NewTextValue.ToLower();
        EgzersizListesi.ItemsSource = tumEgzersizler.Where(x => x.Ad.ToLower().Contains(aranan)).ToList();
    }

    // Listeden bir antrenman seçildiðinde paneli aç
    private void OnEgzersizSecildi(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Egzersiz secilen)
        {
            secilenEgzersiz = secilen;
            LblSecilenEgzersiz.Text = secilen.Ad;
            LblSaatlikKalori.Text = $"{secilen.SaatlikKalori} cal";

            EntDakika.Text = ""; // Önceki süreyi temizle
            HesaplamaPaneli.IsVisible = true;
        }
    }

    // Ekle Butonuna Basýldýðýnda
    private async void OnAntrenmanEkleClicked(object sender, EventArgs e)
    {
        if (secilenEgzersiz != null && double.TryParse(EntDakika.Text, out double dakika) && dakika > 0)
        {
            // Orantý Hesabý: (Dakika / 60) * Saatlik Kalori
            double oran = dakika / 60.0;
            double yakilanKalori = secilenEgzersiz.SaatlikKalori * oran;

            // Ana sayfaya (MainPage) gönder
            MessagingCenter.Send(this, "AntrenmanEklendi", yakilanKalori);

            await DisplayAlert("Tebrikler!", $"{dakika} dakika {secilenEgzersiz.Ad} yaparak {Math.Round(yakilanKalori, 1)} kalori yaktýnýz.", "Tamam");
            await Navigation.PopAsync(); // Sayfayý kapatýp ana sayfaya dön
        }
        else
        {
            await DisplayAlert("Hata", "Lütfen geçerli bir dakika giriniz.", "Tamam");
        }
    }
}