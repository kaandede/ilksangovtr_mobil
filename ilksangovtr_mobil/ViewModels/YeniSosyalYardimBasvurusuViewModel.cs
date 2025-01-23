using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class YeniSosyalYardimBasvurusuViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _selectedYardimTuru;

        [ObservableProperty]
        private string _aciklama;

        public YeniSosyalYardimBasvurusuViewModel()
        {
            // Constructor
        }

        [RelayCommand]
        private async Task BasvuruYap()
        {
            // Başvuru işlemleri
            await Shell.Current.GoToAsync("..");
        }
    }
} 