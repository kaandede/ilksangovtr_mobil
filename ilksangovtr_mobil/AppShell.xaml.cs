using CommunityToolkit.Maui.Extensions;
using ilksangovtr_mobil.ViewModels;
using ilksangovtr_mobil.Views;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ilksangovtr_mobil.Services;
using Microsoft.Maui.Controls;

namespace ilksangovtr_mobil
{
    public partial class AppShell : Shell
    {
        private readonly AuthService _authService;
        private readonly IServiceProvider _serviceProvider;

        public AppShell(AuthService authService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authService = authService;
            _serviceProvider = serviceProvider;

            Routing.RegisterRoute(nameof(Bildirimler), typeof(Bildirimler));
            Routing.RegisterRoute(nameof(SosyalYardimlar), typeof(SosyalYardimlar));
            Routing.RegisterRoute(nameof(YeniSosyalYardimBasvurusu), typeof(YeniSosyalYardimBasvurusu));
            Routing.RegisterRoute(nameof(IkrazHesaplama), typeof(IkrazHesaplama));
            Routing.RegisterRoute(nameof(IkrazSigortaPoliceleri), typeof(IkrazSigortaPoliceleri));
            Routing.RegisterRoute(nameof(Kampanyalar), typeof(Kampanyalar));
            Routing.RegisterRoute(nameof(OtellerKonukevleri), typeof(OtellerKonukevleri));
            Routing.RegisterRoute(nameof(BultenRaporlar), typeof(BultenRaporlar));
            Routing.RegisterRoute(nameof(ChangePasswordPage), typeof(ChangePasswordPage));
            Routing.RegisterRoute(nameof(TesisDetail), typeof(TesisDetail));
            Routing.RegisterRoute(nameof(Duyurular), typeof(Duyurular));
            Routing.RegisterRoute(nameof(DuyuruDetail), typeof(DuyuruDetail));
            Routing.RegisterRoute("KampanyaDetail", typeof(KampanyaDetail));
            Routing.RegisterRoute("PdfViewer", typeof(PdfViewer));
            Routing.RegisterRoute(nameof(AracKampanya), typeof(AracKampanya));
            Routing.RegisterRoute(nameof(SifirAracKampanya), typeof(SifirAracKampanya));
            Routing.RegisterRoute(nameof(SifirAracKampanyaBasvur), typeof(SifirAracKampanyaBasvur));
            Routing.RegisterRoute(nameof(IkinciElAracKampanya), typeof(IkinciElAracKampanya));

            Routing.RegisterRoute(nameof(BildirimDetail), typeof(BildirimDetail));
            Routing.RegisterRoute(nameof(MesajDetail), typeof(MesajDetail));

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (!await _authService.IsAuthenticatedAsync())
                {
                    var loginViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
                    Application.Current.MainPage = new Login(loginViewModel, _authService, _serviceProvider);
                }
            });
        }
    }
}
