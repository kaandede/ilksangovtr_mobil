using CommunityToolkit.Mvvm.ComponentModel;
using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.ViewModels
{
    [QueryProperty(nameof(Bildirim), "Bildirim")]
    public partial class BildirimDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private BildirimItem bildirim;
    }
} 