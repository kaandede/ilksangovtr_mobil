using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(AnaSayfaViewModel anaSayfaViewModel)
        {
            InitializeComponent();
            BindingContext = anaSayfaViewModel;
        }

        async void back_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

    }

}
