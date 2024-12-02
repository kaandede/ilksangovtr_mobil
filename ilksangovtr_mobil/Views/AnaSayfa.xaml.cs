using ilksangovtr_mobil.Models;


namespace ilksangovtr_mobil.Views;

public partial class AnaSayfa : ContentPage
{
    public AnaSayfa(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
		BindingContext = anaSayfaViewModel;
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void Bildirimler_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Bildirimler());
    }

}