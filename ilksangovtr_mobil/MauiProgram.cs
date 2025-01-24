using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ilksangovtr_mobil.Services;
using DevExpress.Maui;
using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .UseMauiCommunityToolkit()
                .UseDevExpress(useLocalization: false)
                .UseDevExpressControls()
                .UseDevExpressCollectionView()
                .UseDevExpressDataGrid()
                .UseDevExpressEditors()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("NexaDemo-Bold.ttf", "NexaHeavy");
                    fonts.AddFont("NexaDemo-Light.ttf", "NexaLight");
                    fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                    fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Aller_Rg.ttf", "AllerRg");
                    fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                    fonts.AddFont("fa-solid-900.ttf", "FaSolid");
                });

            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<DuyuruService>();
            builder.Services.AddScoped<ViewModels.AnaSayfaViewModel>();
            builder.Services.AddScoped<KampanyalarViewModel>();
            builder.Services.AddScoped<AidatViewModel>();
            builder.Services.AddScoped<DuyurularViewModel>();
            builder.Services.AddScoped<DuyuruDetailViewModel>();
            builder.Services.AddScoped<Loading>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<BildirimlerViewModel>();
            builder.Services.AddTransient<UserViewModel>(sp => 
                new UserViewModel(
                    sp.GetRequiredService<AuthService>(),
                    sp));
            builder.Services.AddTransient<MesajDetailViewModel>();
            builder.Services.AddTransient<Login>(sp => 
                new Login(
                    sp.GetRequiredService<LoginViewModel>(),
                    sp.GetRequiredService<AuthService>(),
                    sp));
            builder.Services.AddTransient<AnaSayfaViewModel>();
            builder.Services.AddTransient<AnaSayfa>();
            builder.Services.AddTransient<Bildirimler>();
            builder.Services.AddTransient<User>();
            builder.Services.AddTransient<BildirimDetailViewModel>();
            builder.Services.AddTransient<BildirimDetail>();
            builder.Services.AddTransient<MesajDetailViewModel>();
            builder.Services.AddTransient<MesajDetail>();
            builder.Services.AddScoped<Duyurular>();
            builder.Services.AddScoped<DuyuruDetail>();
            builder.Services.AddScoped<Ikraz>();
            builder.Services.AddScoped<Aidat>();
            builder.Services.AddScoped<SosyalYardimlar>();
            builder.Services.AddScoped<YeniSosyalYardimBasvurusu>();
            builder.Services.AddScoped<ChangePasswordPage>();
            builder.Services.AddScoped<IkrazHesaplama>();
            builder.Services.AddScoped<IkrazSigortaPoliceleri>();
            builder.Services.AddScoped<Kampanyalar>();
            builder.Services.AddScoped<OtellerKonukevleri>();
            builder.Services.AddScoped<BultenRaporlar>();
            builder.Services.AddSingleton<SosyalYardimlarViewModel>();
            builder.Services.AddSingleton<YeniSosyalYardimBasvurusuViewModel>();
            builder.Services.AddTransient<AracKampanya>();
            builder.Services.AddTransient<AracKampanyaViewModel>();
            builder.Services.AddTransient<SifirAracKampanya>();
            builder.Services.AddTransient<SifirAracKampanyaViewModel>();
            builder.Services.AddTransient<SifirAracKampanyaBasvur>();
            builder.Services.AddTransient<SifirAracKampanyaBasvurViewModel>();
            builder.Services.AddTransient<IkinciElAracKampanya>();
            builder.Services.AddTransient<IkinciElAracKampanyaViewModel>();

            // App sınıfını singleton olarak kaydet
            builder.Services.AddSingleton<App>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            DevExpress.Maui.Controls.Initializer.Init();
            return builder.Build();
        }
    }
}
