using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;
using Syncfusion.Maui.Core.Hosting;
using Microsoft.Extensions.Logging;

namespace ilksangovtr_mobil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
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
            builder.Services.AddSingleton<AnaSayfaViewModel>();
            builder.Services.AddSingleton<AnaSayfa>();
            builder.Services.AddSingleton<Login>();
            builder.Services.AddSingleton<Bildirimler>();
            builder.Services.AddSingleton<MainPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
