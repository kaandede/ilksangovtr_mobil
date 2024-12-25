using CommunityToolkit.Maui.Views;
using ilksangovtr_mobil.Models;
using System.Diagnostics;

namespace ilksangovtr_mobil.Views;

public partial class IkinciElAracKampanya : ContentPage
{
    AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();
    private bool isChecked = false;
    public IkinciElAracKampanya(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;

        check_onay.IsChecked = true;
    }

    private void back_AracKampanya_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AracKampanya(anaSayfaViewModel));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        popup.IsOpen = true;
    } 
    private void CancelDeleteClick(object sender, EventArgs e)
    {
        popup.IsOpen = false;
        isChecked = true;
        check_onay.IsChecked = true;
       
        
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (check_onay.IsChecked == false)
        {
            DisplayAlert("Uyar�", "L�tfen Metni Okuyup Onaylay�n�z", "Tamam");
        }
        else
        {
            DisplayAlert("Ba�ar�l�", "Sayfaya Y�nlendiriliyorsunuz", "Tamam");
            popup.IsOpen = false;
        }
    }

    private void check_onay_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!isChecked)
        {
            ((CheckBox)sender).IsChecked = false; // ��aretleme yap�lmas�n
        }
        isChecked = false;
    }

    private async void ikinciel_pdf(object sender, TappedEventArgs e)
    {
        try
        {
            string pdfPath = "2ElAra�KampayaBa�vuruve�demeKo�ullar�Metni.pdf";  // Android i�in �rnek
            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(pdfPath)
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"PDF a��l�rken bir hata olu�tu: {ex.Message}", "Tamam");
        }
    }
}