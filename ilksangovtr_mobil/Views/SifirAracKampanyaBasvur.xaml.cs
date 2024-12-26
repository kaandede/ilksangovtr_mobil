using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class SifirAracKampanyaBasvur : ContentPage
{
    AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();
    public SifirAracKampanyaBasvur(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }

    private void back_basvur_AracKampanya_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SifirAracKampanya(anaSayfaViewModel));
    }
}