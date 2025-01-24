using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using System.Collections.ObjectModel;
using ilksangovtr_mobil.Views;
using System.Threading;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class BildirimlerViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<BildirimItem> bildirimler;

        [ObservableProperty]
        private ObservableCollection<MesajItem> mesajlar;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private bool isRefreshing;

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
        }

        [RelayCommand]
        public async Task LoadData()
        {
            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                await Task.Delay(1000); // API simülasyonu

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    LoadTestData(); // Bildirimler ve Mesajlar zaten LoadTestData içinde temizleniyor
                });
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Veriler yüklenirken bir hata oluştu: {ex.Message}";
                await Shell.Current.DisplayAlert("Hata", ErrorMessage, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task RefreshData()
        {
            try
            {
                IsRefreshing = true;
                
                // API simülasyonu
                await Task.Delay(1000);
                
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
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
                IsRefreshing = false;
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