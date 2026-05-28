using fitkal.Services;
using System.Collections.ObjectModel;

namespace fitkal.Views;

public partial class OgunEklePage : ContentPage
{
    private readonly ApiService _apiService;
    public ObservableCollection<YemekUIModel> SergilenenYemekler { get; set; }
    private YemekUIModel _secilenYemek;

    public OgunEklePage()
    {
        InitializeComponent();
        _apiService = new ApiService();
        SergilenenYemekler = new ObservableCollection<YemekUIModel>();
        YemekListesi.ItemsSource = SergilenenYemekler;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await YemekleriAra("");
    }

    private async Task YemekleriAra(string kelime)
    {
        var gelenBesinler = await _apiService.GetFoodsAsync(kelime);
        SergilenenYemekler.Clear();

        if (gelenBesinler != null)
        {
            foreach (var besin in gelenBesinler)
            {
                SergilenenYemekler.Add(new YemekUIModel
                {
                    Id = besin.Id,
                    Ad = besin.Name,
                    Kalori = besin.Calories,
                    Protein = besin.Protein,
                    Karbonhidrat = besin.Carbohydrate,
                    Yag = besin.Fat,
                    Seker = besin.Sugar
                });
            }
        }
    }

    private async void OnAramaDegisti(object sender, TextChangedEventArgs e)
    {
        await YemekleriAra(e.NewTextValue);
    }

    private void OnYemekSecildi(object sender, SelectionChangedEventArgs e)
    {
        var secilen = e.CurrentSelection.FirstOrDefault() as YemekUIModel;
        if (secilen == null) return;

        _secilenYemek = secilen;

        LblSecilenYemek.Text = secilen.Ad.ToUpper();
        LblPro.Text = $"{secilen.Protein} g";
        LblKarb.Text = $"{secilen.Karbonhidrat} g";
        LblYag.Text = $"{secilen.Yag} g";
        LblSek.Text = $"{secilen.Seker} g";

        EntGram.Text = string.Empty;
        HesaplamaPaneli.IsVisible = true;
    }

    private async void OnYemekEkleClicked(object sender, EventArgs e)
    {
        if (_secilenYemek == null) return;

        if (!double.TryParse(EntGram.Text, out double gram) || gram <= 0)
        {
            await DisplayAlert("Uyarý", "Lütfen geçerli bir gram miktarý girin.", "Tamam");
            return;
        }

        bool basariliMi = await _apiService.AddMealAsync(_secilenYemek.Id, gram);

        if (basariliMi)
        {
            await DisplayAlert("Baþarýlý", "Öðün veritabanýna iþlendi.", "Tamam");
            YemekListesi.SelectedItem = null;
            HesaplamaPaneli.IsVisible = false;
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Hata", "Öðün kaydedilemedi. Backend rotalarýný kontrol edin.", "Tamam");
        }
    }

    private async void OnGeriTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }
}

public class YemekUIModel
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public double Kalori { get; set; }
    public double Protein { get; set; }
    public double Karbonhidrat { get; set; }
    public double Yag { get; set; }
    public double Seker { get; set; }
}