using fitkal.Services;

namespace fitkal.Views;

public partial class MainPage : ContentPage
{
    private readonly ApiService _apiService;

    public MainPage()
    {
        InitializeComponent();
        _apiService = new ApiService();

        if (UstHeader != null)
        {
            UstHeader.MenuTiklandi += (s, e) => OnMenuTapped(null, null);
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await AnaSayfaVerileriniYukle();
    }

    private async Task AnaSayfaVerileriniYukle()
    {
        var profil = await _apiService.GetProfileAsync();
        var ozet = await _apiService.GetDailySummaryAsync();

        if (profil != null)
        {
            LblKullaniciAdi.Text = !string.IsNullOrWhiteSpace(profil.Name)
                ? profil.Name
                : !string.IsNullOrWhiteSpace(profil.Username)
                    ? profil.Username
                    : "Kullanıcı";

            int hedefKalori = profil.GoalCalories ?? 2000;

            double alinanKalori = ozet?.TotalCalories ?? 0;
            double yakilanKalori = ozet?.TotalBurned ?? 0;
            double netKalori = ozet?.NetCalories ?? alinanKalori;
            double kalanKalori = hedefKalori - alinanKalori;

            LblAlinanKalori.Text = $"{alinanKalori:F0} cal";
            LblYakilanKalori.Text = $"{yakilanKalori:F0} cal";
            LblNetKalori.Text = $"{netKalori:F0} cal";
            LblKalanKalori.Text = $"{(kalanKalori < 0 ? 0 : kalanKalori):F0} cal";

            LblProtein.Text = $"{ozet?.TotalProtein ?? 0:F1} g";
            LblKarbonhidrat.Text = $"{ozet?.TotalCarbohydrate ?? 0:F1} g";
            LblYag.Text = $"{ozet?.TotalFat ?? 0:F1} g";
            LblSeker.Text = $"{ozet?.TotalSugar ?? 0:F1} g";

            if (hedefKalori > 0)
            {
                double yuzde = (alinanKalori / hedefKalori) * 100;

                if (yuzde > 100)
                    yuzde = 100;

                if (yuzde < 0)
                    yuzde = 0;

                LblYuzde.Text = $"%{yuzde:F0}";

                double solPay = yuzde == 0 ? 0.1 : yuzde;
                double sagPay = 100 - yuzde == 0 ? 0.1 : 100 - yuzde;

                ProgressGrid.ColumnDefinitions[0].Width =
                    new GridLength(solPay, GridUnitType.Star);

                ProgressGrid.ColumnDefinitions[1].Width =
                    new GridLength(sagPay, GridUnitType.Star);
            }
            else
            {
                LblYuzde.Text = "%0";

                ProgressGrid.ColumnDefinitions[0].Width =
                    new GridLength(0.1, GridUnitType.Star);

                ProgressGrid.ColumnDefinitions[1].Width =
                    new GridLength(100, GridUnitType.Star);
            }
        }
    }

    private async void OnOgunEkleTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new OgunEklePage());
    }

    private async void OnAntrenmanEkleTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new AntrenmanEklePage());
    }

    private void OnMenuTapped(object sender, TappedEventArgs e)
    {
        MenuDropdown.IsVisible = !MenuDropdown.IsVisible;
        MenuBgOverlay.IsVisible = MenuDropdown.IsVisible;
    }

    private async void OnHesapTapped(object sender, TappedEventArgs e)
    {
        MenuDropdown.IsVisible = false;
        MenuBgOverlay.IsVisible = false;

        await Navigation.PushAsync(new ProfilePage());
    }

    private void OnCikisYapTapped(object sender, TappedEventArgs e)
    {
        MenuDropdown.IsVisible = false;
        MenuBgOverlay.IsVisible = false;

        SecureStorage.Default.Remove("jwt_token");
        Preferences.Default.Remove("remember_me");

        Application.Current.MainPage = new LoginPage();
    }
}