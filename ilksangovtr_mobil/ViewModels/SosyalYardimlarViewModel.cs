using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;
using System.Collections.ObjectModel;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class SosyalYardimlarViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<SosyalYardimBasvurular> _sosyalYardimBasvurulars;

        [ObservableProperty]
        private ObservableCollection<SosyalYardimBilgilerim> _sosyalYardimBilgilerims;

        public SosyalYardimlarViewModel()
        {
            _sosyalYardimBasvurulars = new ObservableCollection<SosyalYardimBasvurular>();
            _sosyalYardimBilgilerims = new ObservableCollection<SosyalYardimBilgilerim>();
            LoadData();
        }

        private void LoadData()
        {
            LoadBasvurular();
            LoadBilgilerim();
        }

        private void LoadBasvurular()
        {
            SosyalYardimBasvurulars.Add(new SosyalYardimBasvurular
            {
                YTUR_ADI = "Evlenme",
                YBASDUR_AD = "Ön Başvuru Tamamlandı",
                YBAS_KAYITTARIHI = "01.07.2021"
            });
            // Diğer örnek veriler...
        }

        private void LoadBilgilerim()
        {
            SosyalYardimBilgilerims.Add(new SosyalYardimBilgilerim
            {
                U_TCKIMLIKNO = "12345678901",
                YTUR_ADI = "Evlenme Yardımı",
                YBO_YARDIMMIKTARI = "10.000 TL",
                YKID_ADI = "Tamamlandı"
            });
            // Diğer örnek veriler...
        }

        [RelayCommand]
        private async Task YeniBasvuru()
        {
            await Shell.Current.GoToAsync(nameof(YeniSosyalYardimBasvurusu));
        }
    }
} 