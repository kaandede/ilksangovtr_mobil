using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class KampanyaDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Kampanya _kampanya;

        [RelayCommand]
        private async Task Basvur()
        {
            if (Kampanya == null) return;

            // Kampanya tipine göre yönlendirme
            if (Kampanya.Category == "Araç")
            {
                await Shell.Current.GoToAsync($"{nameof(SifirAracKampanya)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Bilgi", "Başvuru sayfası henüz hazır değil.", "Tamam");
            }
        }
    }
} 