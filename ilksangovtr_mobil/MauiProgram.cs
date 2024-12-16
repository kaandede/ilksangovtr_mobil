using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Core.Hosting;
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
                .UseMauiCommunityToolkit()
                //.ConfigureSyncfusionCore()
                .UseDevExpress(useLocalization: false)
                .UseDevExpressControls()
                .UseDevExpressCollectionView()
                .UseDevExpressDataGrid()
                .UseDevExpress()
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


            builder.Services.AddTransient<AuthService>();
            builder.Services.AddTransient<Loading>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<User>();
            builder.Services.AddSingleton<AnaSayfaViewModel>();
            builder.Services.AddSingleton<AnaSayfa>();
            builder.Services.AddSingleton<Aidat>();
  
#if DEBUG
            builder.Logging.AddDebug();
#endif
            DevExpress.Maui.Controls.Initializer.Init();
            return builder.Build();
        }
    }
}
