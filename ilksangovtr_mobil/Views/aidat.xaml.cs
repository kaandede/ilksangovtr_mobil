using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class Aidat : ContentPage
{
	public Aidat(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }


    private async void Ikraz_pano_copy(object sender, EventArgs e)
    {
        var text = "650004600017888000170004";

        // Metni panoya kopyala
        await Clipboard.SetTextAsync(text);

        // Kullan�c�ya bilgi vermek i�in bir mesaj g�ster
        await DisplayAlert("Ba�ar�l�", "Metin kopyaland�.", "Tamam");
    }
    private async void Aidat_pano_copy(object sender, EventArgs e)
    {
        var text = "110004600017888000170006";

        // Metni panoya kopyala
        await Clipboard.SetTextAsync(text);

        // Kullan�c�ya bilgi vermek i�in bir mesaj g�ster
        await DisplayAlert("Ba�ar�l�", "Metin kopyaland�.", "Tamam");
    }
}