using CommunityToolkit.Mvvm.ComponentModel;

namespace ilksangovtr_mobil.Models
{
    public partial class MesajItem : ObservableObject
    {
        [ObservableProperty]
        private string gonderen;

        [ObservableProperty]
        private string icerik;

        [ObservableProperty]
        private DateTime tarih;

        [ObservableProperty]
        private bool okundu;
    } 
}