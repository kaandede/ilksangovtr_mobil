using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private bool LoginIsSuccessful()
    {
        return true;
    }
    private void Login_Button_Clicked(object sender, EventArgs e)
    {
        var anaSayfaViewModel = new AnaSayfaViewModel();
        Application.Current.MainPage = new AnaSayfa(anaSayfaViewModel);

        if (LoginIsSuccessful())
        {
            // Giriþ baþarýlý ise AppShell'e geç
            Application.Current.MainPage = new AppShell();

            // Kesin route ile gitme
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(AnaSayfa)}");
            });
        }

    }

}