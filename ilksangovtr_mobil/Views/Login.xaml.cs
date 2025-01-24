using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Services;
using ilksangovtr_mobil.ViewModels;
using System.Text.Json;

namespace ilksangovtr_mobil.Views;

public partial class Login : ContentPage
{
    private readonly LoginViewModel _viewModel;
    private readonly AuthService _authService;
    private readonly IServiceProvider _serviceProvider;

    public Login(LoginViewModel viewModel, AuthService authService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _authService = authService;
        _serviceProvider = serviceProvider;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.CheckSavedCredentials();
    }

    private async void Login_Button_Clicked(object sender, EventArgs e)
    {
        if (_viewModel.IsBusy) return;

        try
        {
            _viewModel.IsBusy = true;

            if (string.IsNullOrEmpty(_viewModel.TcKimlikNo) || string.IsNullOrEmpty(_viewModel.Sifre))
            {
                await DisplayAlert("Uyarı", "TC Kimlik No ve Şifre alanları boş bırakılamaz.", "Tamam");
                return;
            }

            await _viewModel.Login();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", "Giriş yapılırken bir hata oluştu: " + ex.Message, "Tamam");
        }
        finally
        {
            _viewModel.IsBusy = false;
        }
    }
}