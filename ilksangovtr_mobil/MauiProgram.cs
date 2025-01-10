using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ilksangovtr_mobil.Services;
using DevExpress.Maui;

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


            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<Loading>();
            builder.Services.AddScoped<Login>();
            builder.Services.AddScoped<User>();
            builder.Services.AddScoped<AnaSayfaViewModel>();
            builder.Services.AddScoped<AnaSayfa>();
            builder.Services.AddScoped<Bildirimler>();
            builder.Services.AddScoped<Ikraz>();
            builder.Services.AddScoped<SifirAracKampanya>();
            builder.Services.AddScoped<SifirAracKampanyaBasvur>();
            builder.Services.AddScoped<Aidat>();
            builder.Services.AddScoped<SosyalYardimlar>();
            builder.Services.AddScoped<YeniSosyalYardimBasvurusu>();
            builder.Services.AddScoped<AracKampanya>();
            builder.Services.AddScoped<IkinciElAracKampanya>();

  
#if DEBUG
            builder.Logging.AddDebug();
#endif
            DevExpress.Maui.Controls.Initializer.Init();
            return builder.Build();
        }
    }
}
