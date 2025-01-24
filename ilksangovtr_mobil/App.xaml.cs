using ilksangovtr_mobil.Services;
using ilksangovtr_mobil.Views;
using ilksangovtr_mobil.ViewModels;
using System.Diagnostics;

namespace ilksangovtr_mobil;

public partial class App : Application
{
    private readonly AuthService _authService;
    private readonly IServiceProvider _serviceProvider;

    public App(AuthService authService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _authService = authService;
        _serviceProvider = serviceProvider;

        // Başlangıçta Loading sayfasını göster
        var loginViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
        MainPage = new Login(loginViewModel, _authService, _serviceProvider);

        // Asenkron olarak kimlik doğrulaması yap
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            try
            {
                if (await _authService.IsAuthenticatedAsync())
                {
                    MainPage = new AppShell(_authService, _serviceProvider);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Authentication error: {ex.Message}");
                // Hata durumunda login sayfasında kal
                var newLoginViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
                MainPage = new Login(newLoginViewModel, _authService, _serviceProvider);
            }
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
#if __ANDROID__
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        window.Created += (s, e) =>
        {
            // Pencere oluşturulduğunda yapılacak işlemler
        };

        window.Activated += (s, e) =>
        {
            // Pencere aktif olduğunda yapılacak işlemler
        };

        window.Width = 1280;
        window.Height = 720;

        return window;
    }
}
