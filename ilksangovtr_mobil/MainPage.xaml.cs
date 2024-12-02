using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

    }

}
