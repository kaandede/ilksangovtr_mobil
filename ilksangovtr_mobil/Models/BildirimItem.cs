using CommunityToolkit.Mvvm.ComponentModel;

namespace ilksangovtr_mobil.Models
{
    public partial class BildirimItem : ObservableObject
    {

        [ObservableProperty]
        private string baslik;

        [ObservableProperty]
        private string icerik;

        [ObservableProperty]
        private DateTime tarih;

        [ObservableProperty]
        private bool okundu;


    }
}
