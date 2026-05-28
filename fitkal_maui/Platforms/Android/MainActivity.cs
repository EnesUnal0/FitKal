using Android.App;
using Android.Content.PM;
using Android.OS;

namespace fitkal;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Durum çubuğunun (en üstteki beyaz şerit) rengini arka planımızla aynı yapıyoruz
        Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#08204B"));
    }
}