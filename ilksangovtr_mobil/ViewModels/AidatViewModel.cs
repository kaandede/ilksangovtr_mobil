using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class AidatViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _toplamOdenenAidatTutari;

        [ObservableProperty]
        private string _sonAidatTutari;

        [ObservableProperty]
        private string _toplamMahsupAidatTutari;

        [ObservableProperty]
        private ObservableCollection<AidatDetay> _aidatDetaylari;

        public AidatViewModel()
        {
            LoadAidatBilgileri();
        }

        private void LoadAidatBilgileri()
        {
            // API'den gelecek veriler için örnek data
            ToplamOdenenAidatTutari = "22.259,69 ₺";
            SonAidatTutari = "1.733,04 ₺";
            ToplamMahsupAidatTutari = "0 ₺";

            AidatDetaylari = new ObservableCollection<AidatDetay>();
            // Örnek veri ekleme
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            AidatDetaylari = new ObservableCollection<AidatDetay>
            {
                new AidatDetay 
                { 
                    Tarih = "01.03.2024",
                    Tutar = "1.733,04 ₺",
                    OdemeDurumu = "Ödendi",
                    Ay = "Mart",
                    Yil = "2024"
                },
                // Diğer örnek veriler...
            };
        }
    }

    public class AidatDetay
    {
        public string Tarih { get; set; }
        public string Tutar { get; set; }
        public string OdemeDurumu { get; set; }
        public string Ay { get; set; }
        public string Yil { get; set; }
    }
} 