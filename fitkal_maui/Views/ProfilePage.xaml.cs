using System;
using Microsoft.Maui.Controls;

namespace fitkal.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();

        // Form alanlarýna baþlangýç mock verilerini dolduruyoruz
        EntAd.Text = "Enes";
        EntSoyad.Text = "Ünal";
        EntKilo.Text = "80";
        EntBoy.Text = "180";
        EntHedefKilo.Text = "75";
        EntHedefKalori.Text = "2500";

        // 17. Madde için DatePicker'a varsayýlan bir tarih atýyoruz
        DpDogumTarihi.Date = new DateTime(2004, 1, 1);

        // 16. Madde için Picker elemanýnýn varsayýlan olarak ilk maddesini seçtiriyoruz
        PckAktivite.SelectedIndex = 2; // "Orta Aktif" seçeneði gelir
    }

    private async void OnGuncelleClicked(object sender, EventArgs e)
    {
        string ad = EntAd.Text;
        string soyad = EntSoyad.Text;
        string hedefKaloriStr = EntHedefKalori.Text;

        // 23. Madde: Form veri doðrulama mantýðý (Boþ býrakýlamaz kontrolü)
        if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
        {
            await DisplayAlert("Hata", "Ad ve Soyad alanlarý boþ býrakýlamaz!", "Tamam");
            return;
        }

        if (double.TryParse(hedefKaloriStr, out double yeniHedef))
        {
            // Kullanýcýnýn seçtiði DatePicker ve Picker verilerini string deðiþkenlere alýyoruz
            string secilenDogumTarihi = DpDogumTarihi.Date.ToString("dd/MM/yyyy");
            string secilenAktivite = PckAktivite.SelectedItem?.ToString() ?? "Belirtilmedi";

            // Ana sayfaya (MainPage) yeni hedefi ve ismi sinyal olarak gönderiyoruz
            MessagingCenter.Send(this, "UpdateProfile", (ad, yeniHedef));

            // Bilgileri ekranda gösteren baþarýlý uyarýsý
            await DisplayAlert("Baþarýlý", $"Profil bilgileriniz güncellendi!\nDoðum Tarihi: {secilenDogumTarihi}\nAktivite: {secilenAktivite}", "Tamam");

            // Güncelleme sonrasý ana sayfaya geri döner
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        else
        {
            await DisplayAlert("Hata", "Lütfen geçerli bir kalori deðeri girin.", "Tamam");
        }
    }
}