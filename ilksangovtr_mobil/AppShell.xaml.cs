using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AnaSayfa", typeof(Views.AnaSayfa));        
        }
    }
}
