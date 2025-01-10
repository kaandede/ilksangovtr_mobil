using CommunityToolkit.Maui.Extensions;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;
using System.ComponentModel;

namespace ilksangovtr_mobil
{
    public partial class AppShell : Shell
    {
        AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();
        public AppShell(AnaSayfaViewModel anaSayfaViewModel)
        {
            InitializeComponent();
            BindingContext = anaSayfaViewModel;

            Routing.RegisterRoute(nameof(Bildirimler), typeof(Bildirimler));
            Routing.RegisterRoute(nameof(SosyalYardimlar), typeof(SosyalYardimlar));
            Routing.RegisterRoute(nameof(AracKampanya), typeof(AracKampanya));
            Routing.RegisterRoute(nameof(IkinciElAracKampanya), typeof(IkinciElAracKampanya));
            Routing.RegisterRoute(nameof(SifirAracKampanya), typeof(SifirAracKampanya));
            Routing.RegisterRoute(nameof(SifirAracKampanyaBasvur), typeof(SifirAracKampanyaBasvur));
            Routing.RegisterRoute(nameof(YeniSosyalYardimBasvurusu), typeof(YeniSosyalYardimBasvurusu));

        }
    

       
    }
}
