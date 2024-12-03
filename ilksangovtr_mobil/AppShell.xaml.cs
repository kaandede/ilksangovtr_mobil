using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

        }

        private void RegisterRoutes()
        {

            Routing.RegisterRoute(nameof(AnaSayfa), typeof(AnaSayfa));
            Routing.RegisterRoute(nameof(Aidat), typeof(Aidat));
            Routing.RegisterRoute(nameof(Ikraz), typeof(Ikraz));
            Routing.RegisterRoute(nameof(User), typeof(User));
            // Diğer sayfalar...
        }
    }
}
