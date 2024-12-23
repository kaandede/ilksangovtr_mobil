using DevExpress.Maui.Controls;
using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class Bildirimler : ContentPage
{
	public Bildirimler(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }


    void back_AnaSayfa_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("///AnaSayfa");
    }
}