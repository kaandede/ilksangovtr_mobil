using ilksangovtr_mobil.Services;
using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class User : ContentPage
{
    private readonly AuthService _authService;
    private readonly UserViewModel _viewModel;

    public User(AuthService authService, UserViewModel viewModel)
	{
		InitializeComponent();
        _authService = authService;
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        _authService.LogOut();
        Shell.Current.GoToAsync($"//{nameof(Login)}");
    }

    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        var changePasswordPage = new ChangePasswordPage();
        await Navigation.PushModalAsync(changePasswordPage);
    }
}