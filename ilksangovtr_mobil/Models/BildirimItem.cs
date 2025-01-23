using CommunityToolkit.Mvvm.ComponentModel;

namespace ilksangovtr_mobil.Models
{
    public partial class BildirimItem : ObservableObject
    {
<<<<<<< HEAD
        [ObservableProperty]
        private string baslik;

        [ObservableProperty]
        private string icerik;

        [ObservableProperty]
        private DateTime tarih;

        [ObservableProperty]
        private bool okundu;
=======
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public bool Okundu { get; set; }
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd
    }
}
