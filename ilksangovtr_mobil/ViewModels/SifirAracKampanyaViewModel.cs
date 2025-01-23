using CommunityToolkit.Mvvm.ComponentModel;

using CommunityToolkit.Mvvm.Input;

using ilksangovtr_mobil.Models;

using ilksangovtr_mobil.Views;

using System.Collections.ObjectModel;



namespace ilksangovtr_mobil.ViewModels

{

    public partial class SifirAracKampanyaViewModel : ObservableObject

    {

        [ObservableProperty]

        private ObservableCollection<AracKampanyaBilgilerim> aracKampanyaBilgilerims;



        [ObservableProperty]

        private bool isBusy;



        [ObservableProperty]

        private string errorMessage;



        public SifirAracKampanyaViewModel()

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



        [RelayCommand]

        private async Task RefreshData()

        {

            await LoadData();

        }



        private void LoadTestData()

        {

            AracKampanyaBilgilerims.Clear();

            // Test verileri

            AracKampanyaBilgilerims.Add(new AracKampanyaBilgilerim

            {

                ARACKAMP_ADI = "2024 Sıfır Araç Kampanyası",

                ARAC_OZELLIKLERI = "Fiat Egea Urban 1.4 Fire 95 HP",

                ARAC_FIYATI = "750.000",

                ARAC_SOZLESME = "İmzalanmadı"

            });



            AracKampanyaBilgilerims.Add(new AracKampanyaBilgilerim

            {

                ARACKAMP_ADI = "2024 Sıfır Araç Kampanyası",

                ARAC_OZELLIKLERI = "Renault Clio Joy 1.0 TCe 90 bg",

                ARAC_FIYATI = "800.000",

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

                var parameters = new Dictionary<string, object>

                {

                    { "Kampanya", kampanya }

                };



                await Shell.Current.GoToAsync(nameof(SifirAracKampanyaBasvur), parameters);

            }

            catch (Exception ex)

            {

                ErrorMessage = $"Başvuru sayfası açılırken bir hata oluştu: {ex.Message}";

                await Shell.Current.DisplayAlert("Hata", ErrorMessage, "Tamam");

            }

        }

    }

}
