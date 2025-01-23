using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using System.Collections.ObjectModel;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class IkinciElAracKampanyaViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AracKampanyaBilgilerim> aracKampanyaBilgilerims;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage;

        public IkinciElAracKampanyaViewModel()
        {
            AracKampanyaBilgilerims = new ObservableCollection<AracKampanyaBilgilerim>();
            LoadData().ConfigureAwait(false);
        }

        [RelayCommand]
        private async Task LoadData()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                // API'den veri çekme simülasyonu
                await Task.Delay(1000);
                LoadTestData();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Veriler yüklenirken bir hata oluştu: {ex.Message}";
                await Shell.Current.DisplayAlert("Hata", ErrorMessage, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void LoadTestData()
        {
            AracKampanyaBilgilerims.Clear();
            AracKampanyaBilgilerims.Add(new AracKampanyaBilgilerim
            {
                ARACKAMP_ADI = "2024 İkinci El Araç Kampanyası",
                ARAC_OZELLIKLERI = "2020 Model Renault Clio Joy 1.0 TCe 90 bg",
                ARAC_FIYATI = "650.000",
                ARAC_SOZLESME = "İmzalanmadı"
            });
        }

        [RelayCommand]
        private async Task BasvuruYap(AracKampanyaBilgilerim kampanya)
        {
            if (kampanya == null)
                return;

            try
            {
                await Shell.Current.DisplayAlert("Başarılı", "Başvurunuz alınmıştır.", "Tamam");
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Başvuru yapılırken bir hata oluştu: {ex.Message}";
                await Shell.Current.DisplayAlert("Hata", ErrorMessage, "Tamam");
            }
        }

        [RelayCommand]
        private async Task RefreshData()
        {
            await LoadData();
        }
    }
} 