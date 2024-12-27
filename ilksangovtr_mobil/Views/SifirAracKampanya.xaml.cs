using DevExpress.Maui.DataGrid;
using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class SifirAracKampanya : ContentPage
{
    AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();
    public SifirAracKampanya(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }


    private void back_sifir_AracKampanya_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AracKampanya(anaSayfaViewModel));
    }

    private void sifirArac_Basvur_Kampanya(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SifirAracKampanyaBasvur(anaSayfaViewModel));
    }

}