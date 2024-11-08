using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class AnaSayfa : ContentPage
{
  
    public AnaSayfa(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
		BindingContext = anaSayfaViewModel;
	}
}