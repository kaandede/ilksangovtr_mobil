using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using System.Collections.ObjectModel;
using System.Threading;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class BildirimlerViewModel : ObservableObject
    {
        [ObservableProperty]
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
            }
            finally
            {
                IsBusy = false;
            }
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
    }
} 