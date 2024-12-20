using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class SosyalYardimlar : ContentPage
{

    public SosyalYardimlar(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }

    async void back_Anasayfa_SoyalYardim(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}