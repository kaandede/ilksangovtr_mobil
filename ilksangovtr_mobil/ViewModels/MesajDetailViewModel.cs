using CommunityToolkit.Mvvm.ComponentModel;
using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.ViewModels
{
    [QueryProperty(nameof(Mesaj), "Mesaj")]
    public partial class MesajDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private MesajItem mesaj;
    }
} 