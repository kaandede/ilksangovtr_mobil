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
                    fonts.AddFont("Nexa-ExtraLight.ttf", "NexaLight");
                    fonts.AddFont("Nexa-Heavy.ttf", "NexaHeavy");
                    fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                    fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Aller_Rg.ttf", "AllerRg");
                    fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                    fonts.AddFont("fa-solid-900.ttf", "FaSolid");
                });

            builder.Services.AddSingleton<DuyuruService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<ViewModels.AnaSayfaViewModel>();
            builder.Services.AddScoped<KampanyalarViewModel>();
            builder.Services.AddScoped<AidatViewModel>();
            builder.Services.AddScoped<DuyurularViewModel>();
            builder.Services.AddScoped<DuyuruDetailViewModel>();
            builder.Services.AddScoped<Loading>();
            builder.Services.AddScoped<Login>();
            builder.Services.AddScoped<User>();
            builder.Services.AddScoped<AnaSayfa>();
            builder.Services.AddScoped<Bildirimler>();
<<<<<<< HEAD
            builder.Services.AddScoped<BildirimDetail>();
            builder.Services.AddScoped<MesajDetail>();
=======
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd
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
<<<<<<< HEAD
            builder.Services.AddSingleton<BildirimlerViewModel>();
            builder.Services.AddTransient<BildirimDetailViewModel>();
            builder.Services.AddTransient<MesajDetailViewModel>();
=======
            builder.Services.AddScoped<BildirimlerViewModel>();
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd
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
<<<<<<< HEAD
            builder.Services.AddTransient<UserViewModel>();
=======
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd

#if DEBUG
            builder.Logging.AddDebug();
#endif
            DevExpress.Maui.Controls.Initializer.Init();
            return builder.Build();
        }
    }
}
