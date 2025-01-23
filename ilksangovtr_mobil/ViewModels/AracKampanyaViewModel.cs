using CommunityToolkit.Mvvm.ComponentModel;

using CommunityToolkit.Mvvm.Input;

using ilksangovtr_mobil.Models;

using ilksangovtr_mobil.Views;

using System.Collections.ObjectModel;



namespace ilksangovtr_mobil.ViewModels

{

    public partial class AracKampanyaViewModel : ObservableObject

    {

        [ObservableProperty]

        private ObservableCollection<AracKampanyaBilgilerim> aracKampanyaBilgilerims;



        [ObservableProperty]

        private ObservableCollection<AracKampanyaKatilimSirasi> aracKampanyaKatilimSirasis;



        [ObservableProperty]

        private ObservableCollection<AracKampanyaParaYatirmaSirasi> aracKampanyaParaYatirmaSirasis;



        [ObservableProperty]

        private int selectedTabIndex;



        [ObservableProperty]

        private bool isBusy;



        [ObservableProperty]

        private string errorMessage;



        public ObservableCollection<TabItem> TabItems { get; } = new()

        {

            new TabItem { Title = "Bilgilerim", Icon = "info.png" },

            new TabItem { Title = "Katılım Sırası", Icon = "list.png" },

            new TabItem { Title = "Para Yatırma Sırası", Icon = "payment.png" }

        };



        public AracKampanyaViewModel()

        {

            AracKampanyaBilgilerims = new ObservableCollection<AracKampanyaBilgilerim>();

            AracKampanyaKatilimSirasis = new ObservableCollection<AracKampanyaKatilimSirasi>();

            AracKampanyaParaYatirmaSirasis = new ObservableCollection<AracKampanyaParaYatirmaSirasi>();

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

            // Bilgilerim tab'ı için

            AracKampanyaBilgilerims.Clear();

            AracKampanyaBilgilerims.Add(new AracKampanyaBilgilerim

            {

                ARACKAMP_ADI = "2024 Sıfır Araç Kampanyası",

                ARAC_OZELLIKLERI = "Citroen C3 Shine 1.2 PureTech 83 HP S&S EAT6",

                ARAC_FIYATI = "950.000",

                ARAC_SOZLESME = "İmzalanmadı"

            });



            // Katılım Sırası tab'ı için

            AracKampanyaKatilimSirasis.Clear();

            AracKampanyaKatilimSirasis.Add(new AracKampanyaKatilimSirasi

            {

                ARAC_OZELLIKLERI = "Citroen C3 Shine 1.2 PureTech 83 HP S&S EAT6",

                SAYI = "45",

                DURUM = "Katılım Sırası Belirlendi",

                KATILIM_TARIHI = "01.01.2024"

            });



            // Para Yatırma Sırası tab'ı için

            AracKampanyaParaYatirmaSirasis.Clear();

            AracKampanyaParaYatirmaSirasis.Add(new AracKampanyaParaYatirmaSirasi

            {

                ARAC_OZELLIKLERI = "Citroen C3 Shine 1.2 PureTech 83 HP S&S EAT6",

                SAYI = "89",

                DURUM = "Para Yatırma Sırası Belirlendi",

                KATILIM_TARIHI = "01.01.2024"

            });

        }



        [RelayCommand]

        private async Task NavigateToSifirAracKampanya()

        {

            try

            {

                await Shell.Current.GoToAsync(nameof(SifirAracKampanya));

            }

            catch (Exception ex)

            {

                ErrorMessage = $"Sıfır Araç Kampanyası sayfası açılırken bir hata oluştu: {ex.Message}";

                await Shell.Current.DisplayAlert("Hata", ErrorMessage, "Tamam");

            }

        }



        [RelayCommand]

        private async Task NavigateToIkinciElAracKampanya()

        {

            try

            {

                await Shell.Current.GoToAsync(nameof(IkinciElAracKampanya));

            }

            catch (Exception ex)

            {

                ErrorMessage = $"İkinci El Araç Kampanyası sayfası açılırken bir hata oluştu: {ex.Message}";

                await Shell.Current.DisplayAlert("Hata", ErrorMessage, "Tamam");

            }

        }

    }

}
