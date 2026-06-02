namespace fitkal.Views;

public partial class HeaderView : ContentView
{
 
    public event EventHandler MenuTiklandi;

    public HeaderView()
    {
        InitializeComponent();
    }

    private void OnMenuIconTapped(object sender, TappedEventArgs e)
    {

        MenuTiklandi?.Invoke(this, EventArgs.Empty);
    }

    
    private async void OnHomeTapped(object sender, TappedEventArgs e)
    {
   
        await Shell.Current.GoToAsync("//MainPage");
    }
}