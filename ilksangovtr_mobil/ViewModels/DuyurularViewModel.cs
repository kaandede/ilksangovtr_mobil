using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using System.Collections.ObjectModel;
using ilksangovtr_mobil.Services;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class DuyurularViewModel : ObservableObject
    {
        private readonly DuyuruService _duyuruService;
        
        [ObservableProperty]
        private ObservableCollection<DuyuruItem> _duyuruItems;

        public DuyurularViewModel(DuyuruService duyuruService)
        {
            _duyuruService = duyuruService;
            _duyuruItems = new ObservableCollection<DuyuruItem>();
            LoadDuyurular();
        }

        private void LoadDuyurular()
        {
            var duyurular = _duyuruService.GetDuyurular(); // Tüm duyuruları al
            DuyuruItems = new ObservableCollection<DuyuruItem>(duyurular);
        }

        [RelayCommand]
        private async Task DuyuruDetail(DuyuruItem duyuru)
        {
            if (duyuru == null) return;

            var parameters = new Dictionary<string, object>
            {
                { "Duyuru", duyuru }
            };
            
            await Shell.Current.GoToAsync($"DuyuruDetail", parameters);
        }
    }
} 