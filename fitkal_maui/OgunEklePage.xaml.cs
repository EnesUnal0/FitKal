namespace fitkal.Views;

// Veritabanýndan gelecek yemek modelimiz
public class Besin
{
    public string Ad { get; set; }
    public double Kalori { get; set; } // 100 gramdaki deðerler
    public double Protein { get; set; }
    public double Karbonhidrat { get; set; }
    public double Yag { get; set; }
    public double Seker { get; set; }
}

public partial class OgunEklePage : ContentPage
{
    // Veritabaný yerine þimdilik kullanacaðýmýz geçici liste
    List<Besin> tumYemekler = new List<Besin>
    {
        new Besin { Ad = "Tavuk Göðsü (Izgara)", Kalori = 165, Protein = 31, Karbonhidrat = 0, Yag = 3.6, Seker = 0 },
        new Besin { Ad = "Beyaz Pirinç Pilavý", Kalori = 130, Protein = 2.7, Karbonhidrat = 28, Yag = 0.3, Seker = 0.1 },
        new Besin { Ad = "Yulaf Ezmesi", Kalori = 389, Protein = 16.9, Karbonhidrat = 66.3, Yag = 6.9, Seker = 0 },
        new Besin { Ad = "Haþlanmýþ Yumurta", Kalori = 155, Protein = 13, Karbonhidrat = 1.1, Yag = 11, Seker = 1.1 },
        new Besin { Ad = "Brokoli", Kalori = 34, Protein = 2.8, Karbonhidrat = 6.6, Yag = 0.4, Seker = 1.7 }
    };

    Besin secilenBesin;

    public OgunEklePage()
    {
        InitializeComponent();
        YemekListesi.ItemsSource = tumYemekler;
    }

    private async void OnGeriTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // Arama Çubuðu Filtrelemesi
    private void OnAramaDegisti(object sender, TextChangedEventArgs e)
    {
        string aranan = e.NewTextValue.ToLower();
        YemekListesi.ItemsSource = tumYemekler.Where(y => y.Ad.ToLower().Contains(aranan)).ToList();
    }

    // Listeden bir yemek seçildiðinde paneli aç ve 100g deðerlerini göster
    private void OnYemekSecildi(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Besin secilen)
        {
            secilenBesin = secilen;
            LblSecilenYemek.Text = secilen.Ad;
            LblPro.Text = $"{secilen.Protein}g";
            LblKarb.Text = $"{secilen.Karbonhidrat}g";
            LblYag.Text = $"{secilen.Yag}g";
            LblSek.Text = $"{secilen.Seker}g";

            EntGram.Text = ""; // Önceki gramý temizle
            HesaplamaPaneli.IsVisible = true;
        }
    }

    // Ekle Butonuna Basýldýðýnda
    private async void OnYemekEkleClicked(object sender, EventArgs e)
    {
        if (secilenBesin != null && double.TryParse(EntGram.Text, out double gram) && gram > 0)
        {
            // Orantý Hesabý: (100 gramdaki deðer / 100) * Yenilen Gram
            double oran = gram / 100.0;

            double hesaplananKalori = secilenBesin.Kalori * oran;
            double hesaplananProtein = secilenBesin.Protein * oran;
            double hesaplananKarb = secilenBesin.Karbonhidrat * oran;
            double hesaplananYag = secilenBesin.Yag * oran;
            double hesaplananSeker = secilenBesin.Seker * oran;

            // Ana sayfaya göndermek üzere deðerleri bir diziye(array) paketliyoruz
            double[] eklenecekDegerler = { hesaplananKalori, hesaplananProtein, hesaplananKarb, hesaplananYag, hesaplananSeker };

            // Verileri yolla
            MessagingCenter.Send(this, "YemekEklendi", eklenecekDegerler);

            await DisplayAlert("Afiyet Olsun!", $"{gram}g {secilenBesin.Ad} günlük özetinize eklendi.", "Tamam");
            await Navigation.PopAsync(); // Sayfayý kapatýp ana sayfaya dön
        }
        else
        {
            await DisplayAlert("Hata", "Lütfen geçerli bir gramaj giriniz.", "Tamam");
        }
    }
}