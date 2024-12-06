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


    async void back_AnaSayfa_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}