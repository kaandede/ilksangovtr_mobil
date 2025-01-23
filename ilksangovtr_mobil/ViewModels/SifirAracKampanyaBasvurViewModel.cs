using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.ViewModels
{
    [QueryProperty(nameof(Kampanya), "Kampanya")]
    public partial class SifirAracKampanyaBasvurViewModel : ObservableObject
    {
        [ObservableProperty]
        private AracKampanyaBilgilerim kampanya;

        [RelayCommand]
        private async Task BasvuruyuTamamla()
        {
            try
            {
                await Shell.Current.DisplayAlert("Başarılı", "Başvurunuz alınmıştır.", "Tamam");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", $"Başvuru yapılırken bir hata oluştu: {ex.Message}", "Tamam");
            }
        }
    }
} 