<<<<<<< HEAD
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
=======
namespace ilksangovtr_mobil.Models
{
    public class MesajItem
    {
        public string Gonderen { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public bool Okundu { get; set; }
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd
    }
} 