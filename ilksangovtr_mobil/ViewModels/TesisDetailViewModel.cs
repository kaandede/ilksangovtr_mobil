using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class TesisDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private SosyalTesis _tesis;

        private readonly OtellerKonukevleriViewModel _otellerViewModel;

        public TesisDetailViewModel()
        {
            _otellerViewModel = new OtellerKonukevleriViewModel();
        }

        public void LoadTesis(string tesisId)
        {
            // Seçilen tesisin ID'sine göre tesisi bul
            var secilenTesis = _otellerViewModel.Tesisler.FirstOrDefault(t => t.Id == tesisId);
            
            if (secilenTesis != null)
            {
                Tesis = secilenTesis;
            }
        }

        [RelayCommand]
        private async Task ReservasyonAsync()
        {
            await Shell.Current.DisplayAlert("Rezervasyon", "Rezervasyon sistemi yakında aktif olacaktır.", "Tamam");
        }
    }
} 