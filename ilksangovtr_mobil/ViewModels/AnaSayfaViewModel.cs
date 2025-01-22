using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Services;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class AnaSayfaViewModel : ObservableObject
    {
        private readonly DuyuruService _duyuruService;
        
        [ObservableProperty]
        private ObservableCollection<DuyuruItem> _duyuruItems = new();

        public AnaSayfaViewModel(DuyuruService duyuruService)
        {
            _duyuruService = duyuruService;
            LoadDuyurular();
        }

        private void LoadDuyurular()
        {
            var duyurular = _duyuruService.GetDuyurular(3); // Sadece 3 duyuru al
            DuyuruItems = new ObservableCollection<DuyuruItem>(duyurular);
        }
    }
} 