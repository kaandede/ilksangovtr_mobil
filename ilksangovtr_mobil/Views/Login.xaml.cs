using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private void Login_Button_Clicked(object sender, EventArgs e)
    {
        var anaSayfaViewModel = new AnaSayfaViewModel();
        Application.Current.MainPage = new AnaSayfa(anaSayfaViewModel);

    }
}