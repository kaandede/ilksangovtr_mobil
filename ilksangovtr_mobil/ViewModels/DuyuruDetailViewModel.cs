using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class DuyuruDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private DuyuruItem _duyuru;

        [RelayCommand]
        private async Task DetayliBilgi()
        {
            if (string.IsNullOrEmpty(Duyuru?.Duyuru_Url)) return;

            var parameters = new Dictionary<string, object>
            {
                { "PdfUrl", Duyuru.Duyuru_Url },
                { "DosyaAdi", Duyuru.Duyuru_Title },
                { "Baslik", Duyuru.Duyuru_Title }
            };

            await Shell.Current.GoToAsync($"{nameof(PdfViewer)}", parameters);
        }
    }
} 