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
        Shell.Current.GoToAsync(nameof(MainPage));
    }

    private void Bildirimler_Clicked(object sender, EventArgs e)
    {
        var anaSayfaViewModel = new AnaSayfaViewModel();
        Navigation.PushAsync(new Bildirimler(anaSayfaViewModel));
    }  
    
    private void Click_SosyalYardimlar(object sender, EventArgs e)
    {
        var anaSayfaViewModel = new AnaSayfaViewModel();
        Navigation.PushAsync(new SosyalYardimlar(anaSayfaViewModel));
    }

}