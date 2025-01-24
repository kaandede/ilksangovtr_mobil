using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Services;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class AnaSayfaViewModel : ObservableObject
    {
        private readonly AuthService _authService;
        private readonly KampanyalarViewModel _kampanyalarViewModel;
        private readonly AidatViewModel _aidatViewModel;
        private readonly DuyuruService _duyuruService;

        [ObservableProperty]
        private ObservableCollection<DuyuruItem> duyuruItems = new();

        [ObservableProperty]
        private string kullaniciSelamlama = "Merhaba";

        public AidatViewModel AidatVM => _aidatViewModel;
        public KampanyalarViewModel KampanyalarVM => _kampanyalarViewModel;

        public AnaSayfaViewModel(
            AuthService authService, 
            KampanyalarViewModel kampanyalarViewModel,
            AidatViewModel aidatViewModel,
            DuyuruService duyuruService)
        {
            _authService = authService;
            _kampanyalarViewModel = kampanyalarViewModel;
            _aidatViewModel = aidatViewModel;
            _duyuruService = duyuruService;

            // Constructor'da başlangıç yüklemelerini yap
            LoadUserInfoAsync();
            LoadDuyurular();
            _kampanyalarViewModel.LoadKampanyalar(); // Artık public metoda erişebiliyoruz
        }

        public async Task LoadUserInfoAsync()
        {
            try
            {
                var userInfo = await _authService.GetCurrentUser();
                if (userInfo != null)
                {
                    var turkiyeSaatDilimi = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
                    var suAn = TimeZoneInfo.ConvertTime(DateTimeOffset.Now, turkiyeSaatDilimi);
                    var selamlamaSaati = suAn.Hour;
                    
                    Debug.WriteLine($"UTC Saat: {DateTimeOffset.UtcNow}");
                    Debug.WriteLine($"Yerel Saat: {DateTimeOffset.Now}");
                    Debug.WriteLine($"Türkiye Saati: {suAn}");
                    Debug.WriteLine($"Saat Dilimi: {turkiyeSaatDilimi.DisplayName}");
                    Debug.WriteLine($"Mevcut saat: {selamlamaSaati}"); 

                    var selamlama = selamlamaSaati switch
                    {
                        >= 5 and < 12 => "Günaydın",
                        >= 12 and < 18 => "İyi Günler",
                        _ => "İyi Akşamlar"
                    };

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        KullaniciSelamlama = $"{selamlama}, {userInfo.Ad} {userInfo.Soyad}";
                        Debug.WriteLine($"Selamlama mesajı: {selamlama} (Saat: {selamlamaSaati})");
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadUserInfo Error: {ex.Message}");
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    KullaniciSelamlama = "Merhaba";
                });
            }
        }

        private void LoadDuyurular()
        {
            var duyurular = _duyuruService.GetDuyurular(3);
            DuyuruItems = new ObservableCollection<DuyuruItem>(duyurular);
        }
    }
} 