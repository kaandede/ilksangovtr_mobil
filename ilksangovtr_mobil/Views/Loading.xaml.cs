using ilksangovtr_mobil.Services;

namespace ilksangovtr_mobil.Views;

public partial class Loading : ContentPage
{
    private readonly AuthService _authService;

    public Loading(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync($"//{nameof(AnaSayfa)}");
        }
        else
        {

            await Shell.Current.GoToAsync($"//{nameof(Login)}");
        }

    }
}