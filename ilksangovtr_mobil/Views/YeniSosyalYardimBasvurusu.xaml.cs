using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class YeniSosyalYardimBasvurusu : ContentPage
{
    AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();
    public YeniSosyalYardimBasvurusu(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }

    private void back_SoyalYardim_geri(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SosyalYardimlar(anaSayfaViewModel));
    }
}