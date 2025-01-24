using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using System.Collections.ObjectModel;
using System.Threading;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ilksangovtr_mobil.Views;
=======
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd

namespace ilksangovtr_mobil.ViewModels
{
    public partial class BildirimlerViewModel : ObservableObject
    {
        [ObservableProperty]
<<<<<<< HEAD
        private ObservableCollection<BildirimItem> bildirimler;

        [ObservableProperty]
        private ObservableCollection<MesajItem> mesajlar;


        [ObservableProperty]

        private bool isBusy;



        [ObservableProperty]

        private string errorMessage;

        // Mevcut bildirimleri ve mesajları tutmak için private listeler
        private List<BildirimItem> _tumBildirimler;
        private List<MesajItem> _tumMesajlar;

        public BildirimlerViewModel()
        {
            Bildirimler = new ObservableCollection<BildirimItem>();
            Mesajlar = new ObservableCollection<MesajItem>();
            _tumBildirimler = new List<BildirimItem>();
            _tumMesajlar = new List<MesajItem>();
            
            // İlk kez test verilerini yükle
            LoadTestData();
            LoadData().ConfigureAwait(false);
        }

        [RelayCommand]
        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                // API simülasyonu
                await Task.Delay(1000);

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    // Mevcut verileri temizle
                    Bildirimler.Clear();
                    Mesajlar.Clear();
                    // Test verilerini yükle
                    LoadTestData();
                });
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Veriler yüklenirken bir hata oluştu: {ex.Message}";
                await Shell.Current.DisplayAlert("Hata", ErrorMessage, "Tamam");
=======
        private ObservableCollection<BildirimItem> _bildirimler;

        [ObservableProperty]
        private ObservableCollection<MesajItem> _mesajlar;

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private bool _isBusy;

        public BildirimlerViewModel()
        {
            _bildirimler = new ObservableCollection<BildirimItem>();
            _mesajlar = new ObservableCollection<MesajItem>();
            LoadData();
        }

        public void LoadData()
        {
            if (IsBusy) return;
            
            try
            {
                IsBusy = true;
                LoadBildirimler();
                LoadMesajlar();
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd
            }
            finally
            {
                IsBusy = false;
            }
        }

<<<<<<< HEAD
        [RelayCommand]
        private async Task RefreshData()
        {
            try
            {
                IsBusy = true;
                
                // API simülasyonu
                await Task.Delay(1000);
                
                // Mevcut verileri temizle ve yeniden yükle
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Bildirimler.Clear();
                    Mesajlar.Clear();
                    LoadTestData();
                });
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Veriler yenilenirken bir hata oluştu: {ex.Message}";
                await Shell.Current.DisplayAlert("Hata", ErrorMessage, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void LoadTestData()
        {
            // Her seferinde yeni test verileri oluştur
            _tumBildirimler.Clear();
            _tumMesajlar.Clear();

            // Rastgele bildirimler oluştur
            var random = new Random();
            var now = DateTime.Now;

            _tumBildirimler.Add(new BildirimItem
            {
                Baslik = "Araç Kampanyası",
                Icerik = "Başvurunuz hakkında bilgi",
                Tarih = now.AddMinutes(-random.Next(5, 30)),
                Okundu = false
            });

            _tumBildirimler.Add(new BildirimItem
            {
                Baslik = "Transfer ve Döviz İşlemleri",
                Icerik = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza iade edildi.",
                Tarih = now.AddMinutes(-random.Next(31, 60)),
                Okundu = random.Next(2) == 0 // Rastgele okundu durumu
            });

            _tumBildirimler.Add(new BildirimItem
            {
                Baslik = "Transfer ve Döviz İşlemleri 2",
                Icerik = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza iade edildi. 2",
                Tarih = now.AddMinutes(-random.Next(61, 90)),
                Okundu = random.Next(2) == 0 // Rastgele okundu durumu
            });

            // Her refresh'te yeni bir mesaj ekle
            if (random.Next(2) == 0) // %50 ihtimalle yeni mesaj
            {
                _tumMesajlar.Add(new MesajItem
                {
                    Gonderen = "İLKSAN",
                    Icerik = $"Yeni mesaj #{random.Next(1000, 9999)}",
                    Tarih = now.AddMinutes(-random.Next(5, 30)),
                    Okundu = false
                });
            }

            _tumMesajlar.Add(new MesajItem
            {
                Gonderen = "İLKSAN",
                Icerik = "Merhaba, başvurunuz alınmıştır.",
                Tarih = now.AddMinutes(-random.Next(31, 60)),
                Okundu = random.Next(2) == 0 // Rastgele okundu durumu
            });

            // ObservableCollection'ları güncelle
            Bildirimler.Clear();
            Mesajlar.Clear();
            
            // Tarihe göre sırala (en yeniler üstte)
            foreach (var bildirim in _tumBildirimler.OrderByDescending(b => b.Tarih))
            {
                Bildirimler.Add(bildirim);
            }
            
            foreach (var mesaj in _tumMesajlar.OrderByDescending(m => m.Tarih))
            {
                Mesajlar.Add(mesaj);
            }

        private void LoadBildirimler()
        {
            var list = new List<BildirimItem>
            {
                new BildirimItem 
                { 
                    Baslik = "Aidat Ödemesi",
                    Icerik = "Ocak 2024 aidat ödemesi yapıldı",
                    Tarih = DateTime.Now.AddDays(-1),
                    Okundu = false
                },
                new BildirimItem 
                { 
                    Baslik = "Sosyal Yardım",
                    Icerik = "Sosyal yardım başvurunuz onaylandı",
                    Tarih = DateTime.Now.AddDays(-2),
                    Okundu = true
                }
            };

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Bildirimler.Clear();
                foreach (var item in list)
                {
                    Bildirimler.Add(item);
                }
            });
        }

        private void LoadMesajlar()
        {
            var list = new List<MesajItem>
            {
                new MesajItem 
                { 
                    Gonderen = "İLKSAN Destek",
                    Icerik = "Başvurunuz hakkında bilgi",
                    Tarih = DateTime.Now.AddHours(-2),
                    Okundu = false
                },
                new MesajItem 
                { 
                    Gonderen = "Sistem",
                    Icerik = "Hoş geldiniz",
                    Tarih = DateTime.Now.AddDays(-1),
                    Okundu = true
                }
            };

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Mesajlar.Clear();
                foreach (var item in list)
                {
                    Mesajlar.Add(item);
                }
            });
        }

        [RelayCommand]
        private async Task RefreshData()
        {
            if (IsRefreshing || IsBusy)
                return;

            try
            {
                IsRefreshing = true;
                await Task.Delay(1000); // Simüle edilmiş yükleme süresi
                LoadData();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Refresh Error: {ex.Message}");
            }
            finally
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    IsRefreshing = false;
                });
            }

        }

        public void AddBildirim(BildirimItem bildirim)
        {
            Bildirimler.Insert(0, bildirim);
        }

        public void AddMesaj(MesajItem mesaj)
        {
            Mesajlar.Insert(0, mesaj);
        }


        [RelayCommand]
        private async Task BildirimTapped(BildirimItem bildirim)
        {
            if (!bildirim.Okundu)
            {
                bildirim.Okundu = true;
                // Gerçek uygulamada API'ye bildirim okundu bilgisi gönderilecek
                
                // Ana listedeki bildirimi de güncelle
                var originalBildirim = _tumBildirimler.FirstOrDefault(b => b == bildirim);
                if (originalBildirim != null)
                {
                    originalBildirim.Okundu = true;
                }
            }
            
            var parameters = new Dictionary<string, object>
            {
                { "Bildirim", bildirim }
            };
            await Shell.Current.GoToAsync(nameof(BildirimDetail), parameters);
        }

        [RelayCommand]
        private async Task MesajTapped(MesajItem mesaj)
        {
            if (!mesaj.Okundu)
            {
                mesaj.Okundu = true;
                // Gerçek uygulamada API'ye mesaj okundu bilgisi gönderilecek
                
                // Ana listedeki mesajı da güncelle
                var originalMesaj = _tumMesajlar.FirstOrDefault(m => m == mesaj);
                if (originalMesaj != null)
                {
                    originalMesaj.Okundu = true;
                }
            }
            
            var parameters = new Dictionary<string, object>
            {
                { "Mesaj", mesaj }
            };
            await Shell.Current.GoToAsync(nameof(MesajDetail), parameters);
        }

    }
} 