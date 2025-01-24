using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class KampanyalarViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Kampanya> _kampanyalar;

        [ObservableProperty]
        private ObservableCollection<Kampanya> _aktifKampanyalar;

        [ObservableProperty]
        private ObservableCollection<string> _kategoriler;

        [ObservableProperty]
        private string _selectedKategori;

        [ObservableProperty]
        private bool _isBusy;

        private List<Kampanya> _allKampanyalar;

        public KampanyalarViewModel()
        {
            _allKampanyalar = new List<Kampanya>();
            Kampanyalar = new ObservableCollection<Kampanya>();
            AktifKampanyalar = new ObservableCollection<Kampanya>();
            InitializeKategoriler();
        }

        private void InitializeKategoriler()
        {
            Kategoriler = new ObservableCollection<string>
            {
                "Tümü",
                "Eğitim",
                "Konaklama",
                "Sağlık",
                "Araç"
            };
            SelectedKategori = "Tümü";
        }

        [RelayCommand]
        public async Task LoadKampanyalar()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                // Örnek kampanya verileri
                var kampanyalar = new List<Kampanya>
                {
                    new Kampanya
                    {
                        Id = "1",
                        Title = "Kırıkkale Üniversitesi Yüksek Lisans Fırsatı",
                        Description = "2023-2024 Bahar Dönemi başvuruları başladı. İLKSAN üyelerine özel avantajlar.",
                        Image = "back4.png",
                        Category = "Eğitim",
                        ValidUntil = "Son Başvuru: 15.03.2024",
                        IsFeatured = true,
                        ButtonText = "HEMEN BAŞVUR"
                    },
                    new Kampanya
                    {
                        Id = "2",
                        Title = "Özel Hastanelerde %20 İndirim",
                        Description = "Anlaşmalı hastanelerde İLKSAN üyelerine özel indirimler.",
                        Image = "back5.png",
                        Category = "Sağlık",
                        ValidUntil = "31.12.2024'e kadar geçerli",
                        ButtonText = "DETAYLAR"
                    },
                    new Kampanya
                    {
                        Id = "3",
                        Title = "Sıfır Araç Kampanyası",
                        Description = "İLKSAN üyelerine özel sıfır araç fırsatları.",
                        Image = "back6.png",
                        Category = "Araç",
                        ValidUntil = "Stoklar ile sınırlıdır",
                        ButtonText = "BAŞVUR"
                    }
                };

                _allKampanyalar = kampanyalar;
                Kampanyalar = new ObservableCollection<Kampanya>(kampanyalar);
                AktifKampanyalar = new ObservableCollection<Kampanya>(kampanyalar.Take(3));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Kampanyalar yüklenirken hata oluştu: {ex.Message}");
                await Shell.Current.DisplayAlert("Hata", "Kampanyalar yüklenirken bir hata oluştu.", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private void FilterKampanyalar(string kategori)
        {
            if (string.IsNullOrEmpty(kategori)) return;

            try
            {
                SelectedKategori = kategori;

                if (kategori == "Tümü")
                {
                    Kampanyalar = new ObservableCollection<Kampanya>(_allKampanyalar);
                }
                else
                {
                    var filteredKampanyalar = _allKampanyalar.Where(k => k.Category == kategori).ToList();
                    Kampanyalar = new ObservableCollection<Kampanya>(filteredKampanyalar);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Kampanyalar filtrelenirken hata oluştu: {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task KampanyaDetail(Kampanya kampanya)
        {
            if (kampanya == null) return;

            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "Kampanya", kampanya }
                };

                await Shell.Current.GoToAsync($"{nameof(KampanyaDetail)}", parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Kampanya detayına giderken hata oluştu: {ex.Message}");
                await Shell.Current.DisplayAlert("Hata", "Kampanya detayı açılırken bir hata oluştu.", "Tamam");
            }
        }

        [RelayCommand]
        private async Task TumunuGor()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(Kampanyalar));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Tüm kampanyalar sayfasına giderken hata oluştu: {ex.Message}");
                await Shell.Current.DisplayAlert("Hata", "Sayfa açılırken bir hata oluştu.", "Tamam");
            }
        }
    }
}