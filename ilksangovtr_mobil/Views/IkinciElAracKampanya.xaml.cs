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
            string tempFile = Path.Combine(FileSystem.CacheDirectory, "2ElAracKampayaBasvuruveOdemeKosullariMetni.pdf");

            using (var stream = await FileSystem.OpenAppPackageFileAsync("2ElAracKampayaBasvuruveOdemeKosullariMetni.pdf"))
            using (var fileStream = File.Create(tempFile))
            {
                await stream.CopyToAsync(fileStream);
            }

            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(tempFile)
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", "PDF dosyas� a��l�rken bir hata olu�tu: " + ex.Message, "Tamam");
        }
    }
}