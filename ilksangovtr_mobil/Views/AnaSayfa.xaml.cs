using ilksangovtr_mobil.Models;


namespace ilksangovtr_mobil.Views;

public partial class AnaSayfa : ContentPage
{
    AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();
    public AnaSayfa(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
		BindingContext = anaSayfaViewModel;
    }


    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new MainPage(anaSayfaViewModel));
     
    }

    private void Bildirimler_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Bildirimler(anaSayfaViewModel));
    }  
    
    private void Click_SosyalYardimlar(object sender, EventArgs e)
    {
   
        Navigation.PushAsync(new SosyalYardimlar(anaSayfaViewModel));
    } 
    private void Click_AracKampanya(object sender, EventArgs e)
    {
   
        Navigation.PushAsync(new AracKampanya(anaSayfaViewModel));
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new MainPage(anaSayfaViewModel));
    }
}