using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class Aidat : ContentPage
{
	private readonly AidatViewModel _viewModel;

	public Aidat(AidatViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	private async void Ikraz_pano_copy(object sender, EventArgs e)
	{
		var text = "650004600017888000170004";

		// Metni panoya kopyala
		await Clipboard.SetTextAsync(text);

		// Kullanıcıya bilgi vermek için bir mesaj göster
		await DisplayAlert("Başarılı", "Metin kopyalandı.", "Tamam");
	}
	private async void Aidat_pano_copy(object sender, EventArgs e)
	{
		var text = "110004600017888000170006";

		// Metni panoya kopyala
		await Clipboard.SetTextAsync(text);

		// Kullanıcıya bilgi vermek için bir mesaj göster
		await DisplayAlert("Başarılı", "Metin kopyalandı.", "Tamam");
	}
}