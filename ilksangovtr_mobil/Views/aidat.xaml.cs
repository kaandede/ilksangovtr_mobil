using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class Aidat : ContentPage
{
	public Aidat()
	{
		InitializeComponent();
        BindingContext = new AnaSayfaViewModel();
    }

}