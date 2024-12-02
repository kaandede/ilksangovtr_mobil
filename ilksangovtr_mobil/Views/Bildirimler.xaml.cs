using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class Bildirimler : ContentPage
{
	public Bildirimler()
	{
		InitializeComponent();
    }

    private void back_AnaSayfa_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }

}