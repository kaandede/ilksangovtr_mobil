using ilksangovtr_mobil.Services;

namespace ilksangovtr_mobil.Views;

public partial class User : ContentPage
{
    private readonly AuthService _authService;

    public User(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        _authService.LogOut();
        Shell.Current.GoToAsync($"//{nameof(Login)}");
    }
}