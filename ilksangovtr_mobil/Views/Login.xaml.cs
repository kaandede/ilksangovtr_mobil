using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Services;

namespace ilksangovtr_mobil.Views;

public partial class Login : ContentPage
{
    private readonly AuthService _authService;

    public Login(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    //private bool LoginIsSuccessful()
    //{
    //    return true;
    //}
    private async void Login_Button_Clicked(object sender, EventArgs e)
    {
       // var anaSayfaViewModel = new AnaSayfaViewModel();
        //Application.Current.MainPage = new AnaSayfa(anaSayfaViewModel);


        _authService.Login();
        await Shell.Current.GoToAsync($"//{nameof(AnaSayfa)}");

        //if (LoginIsSuccessful())
        //{
        //    Application.Current.MainPage = new AppShell();

        //}

    }

}