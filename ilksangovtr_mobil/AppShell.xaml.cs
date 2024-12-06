using CommunityToolkit.Maui.Extensions;
using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AnaSayfa), typeof(AnaSayfa));
            Routing.RegisterRoute(nameof(Loading), typeof(Loading));
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(Bildirimler), typeof(Bildirimler));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(Aidat), typeof(Aidat));
            Routing.RegisterRoute(nameof(Ikraz), typeof(Ikraz));
            Routing.RegisterRoute(nameof(User), typeof(User));

            FlyoutIcon = ImageSource.FromFile("bars_ince.png");

        }       
    }
}
