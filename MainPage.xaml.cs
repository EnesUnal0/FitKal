namespace fitkal;
using fitkal.Views;

public partial class MainPage : ContentPage
{
    private string mevcutKullaniciAdi = "Enes";
    private double hedefKalori = 2500;

    private double alinanKalori = 0;
    private double yakilanKalori = 0;

    private double protein = 0;
    private double karbonhidrat = 0;
    private double yag = 0;
    private double seker = 0;

    public MainPage()
    {
        InitializeComponent();
        EkraniGuncelle();

        HeaderView.MenuyeTiklandi += (s, e) => MenuyuAcKapat();

        MessagingCenter.Subscribe<ProfilePage, (string, double)>(this, "UpdateProfile", (sender, data) =>
        {
            mevcutKullaniciAdi = data.Item1;
            hedefKalori = data.Item2;
            EkraniGuncelle();
        });

        MessagingCenter.Subscribe<OgunEklePage, double[]>(this, "YemekEklendi", (sender, degerler) =>
        {
            alinanKalori += Math.Round(degerler[0], 1);
            protein += Math.Round(degerler[1], 1);
            karbonhidrat += Math.Round(degerler[2], 1);
            yag += Math.Round(degerler[3], 1);
            seker += Math.Round(degerler[4], 1);

            EkraniGuncelle();
        });

        // YENİ EKLENEN KISIM: Antrenman sayfasından gelen kalori verisini yakalar
        MessagingCenter.Subscribe<AntrenmanEklePage, double>(this, "AntrenmanEklendi", (sender, yakilan) =>
        {
            yakilanKalori += Math.Round(yakilan, 1);
            EkraniGuncelle(); // Ekranda yazan sayıları ve barı anında yeniler
        });
    }

    private void EkraniGuncelle()
    {
        double netKalori = alinanKalori - yakilanKalori;
        double kalanKalori = hedefKalori - netKalori;

        LblKullaniciAdi.Text = mevcutKullaniciAdi;

        LblAlinanKalori.Text = $"{alinanKalori} cal";
        LblYakilanKalori.Text = $"{yakilanKalori} cal";
        LblNetKalori.Text = $"{netKalori} cal";
        LblKalanKalori.Text = $"{kalanKalori} cal";

        LblProtein.Text = $"{protein} g";
        LblKarbonhidrat.Text = $"{karbonhidrat} g";
        LblYag.Text = $"{yag} g";
        LblSeker.Text = $"{seker} g";

        CalorieProgressGuncelle(alinanKalori, hedefKalori);
    }

    private void CalorieProgressGuncelle(double alinan, double hedef)
    {
        if (hedef <= 0) return;

        double oran = alinan / hedef;
        if (oran > 1) oran = 1;

        int yuzde = (int)(oran * 100);

        if (LblYuzde != null)
        {
            LblYuzde.Text = $"%{yuzde}";
        }

        double doluPayi = yuzde;
        double bosPayi = 100 - yuzde;

        if (bosPayi <= 0) bosPayi = 0.1;
        if (doluPayi <= 0) doluPayi = 0.1;

        if (ProgressGrid != null)
        {
            ProgressGrid.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(doluPayi, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(bosPayi, GridUnitType.Star) }
            };
        }

        if (ProgressBarFill != null)
        {
            if (yuzde < 50)
                ProgressBarFill.BackgroundColor = Color.FromArgb("#4CAF50");
            else if (yuzde >= 50 && yuzde < 85)
                ProgressBarFill.BackgroundColor = Color.FromArgb("#FF9800");
            else
                ProgressBarFill.BackgroundColor = Color.FromArgb("#E53935");
        }
    }

    private void MenuyuAcKapat()
    {
        bool isVisible = !MenuDropdown.IsVisible;
        MenuDropdown.IsVisible = isVisible;
        MenuBgOverlay.IsVisible = isVisible;
    }

    private void OnMenuTapped(object sender, EventArgs e)
    {
        MenuyuAcKapat();
    }

    private async void OnHesapTapped(object sender, EventArgs e)
    {
        MenuyuAcKapat();
        await Navigation.PushAsync(new ProfilePage());
    }

    private async void OnAyarlarTapped(object sender, EventArgs e)
    {
        MenuyuAcKapat();
        await DisplayAlert("Ayarlar", "Ayarlar sayfamız yakında eklenecek!", "Tamam");
    }

    private async void OnOgunEkleTapped(object sender, EventArgs e)
    {
        MenuyuAcKapat();
        await Navigation.PushAsync(new OgunEklePage());
    }

    private async void OnAntrenmanEkleTapped(object sender, EventArgs e)
    {
        MenuyuAcKapat();
        await Navigation.PushAsync(new AntrenmanEklePage()); // YENİ: Antrenman Ekle sayfasına yönlendirir
    }
}