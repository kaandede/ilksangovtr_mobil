using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using System.Collections.ObjectModel;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class BultenRaporlarViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Bulten> _bultenler;

        [ObservableProperty]
        private ObservableCollection<Rapor> _raporlar;

        public BultenRaporlarViewModel()
        {
            LoadBultenler();
            LoadRaporlar();
        }

        [RelayCommand]
        private void LoadBultenler()
        {
            var bultenListesi = new List<Bulten>();
            
            // Test için örnek PDF URL'leri
            var pdfUrls = new[]
            {
                "https://www.africau.edu/images/default/sample.pdf",
                "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
                "https://www.adobe.com/support/products/enterprise/knowledgecenter/media/c4611_sample_explain.pdf"
            };

            // 2024'ten 2013'e kadar bültenleri ekle
            for (int yil = 2024; yil >= 2013; yil--)
            {
                bultenListesi.Add(new Bulten
                {
                    Id = yil.ToString(),
                    Baslik = $"{yil} Yılı İLKSAN Bülteni",
                    Tarih = $"{yil}",
                    // Örnek PDF'leri dönüşümlü olarak kullan
                    PdfUrl = pdfUrls[(2024 - yil) % pdfUrls.Length],
                    DosyaAdi = $"ILKSAN_{yil}_Bulten.pdf"
                });
            }

            Bultenler = new ObservableCollection<Bulten>(bultenListesi);
        }

        [RelayCommand]
        private void LoadRaporlar()
        {
            var raporListesi = new List<Rapor>();
            
            // Test için örnek PDF URL'leri
            var pdfUrls = new[]
            {
                "https://www.adobe.com/support/products/enterprise/knowledgecenter/media/c4611_sample_explain.pdf",
                "https://www.africau.edu/images/default/sample.pdf",
                "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf"
            };

            // 2024'ten 2013'e kadar raporları ekle
            for (int yil = 2024; yil >= 2013; yil--)
            {
                raporListesi.Add(new Rapor
                {
                    Id = yil.ToString(),
                    Baslik = $"{yil} Faaliyet Raporu",
                    Aciklama = $"{yil} yılı detaylı faaliyet raporu",
                    Tarih = $"{yil}",
                    // Örnek PDF'leri dönüşümlü olarak kullan
                    PdfUrl = pdfUrls[(2024 - yil) % pdfUrls.Length],
                    DosyaAdi = $"ILKSAN_{yil}_Rapor.pdf"
                });
            }

            Raporlar = new ObservableCollection<Rapor>(raporListesi);
        }

        [RelayCommand]
        private async Task PdfGoruntuleAsync(object param)
        {
            string pdfUrl = "";
            string dosyaAdi = "";
            string baslik = "";

            if (param is Bulten bulten)
            {
                pdfUrl = bulten.PdfUrl;
                dosyaAdi = bulten.DosyaAdi;
                baslik = bulten.Baslik;
            }
            else if (param is Rapor rapor)
            {
                pdfUrl = rapor.PdfUrl;
                dosyaAdi = rapor.DosyaAdi;
                baslik = rapor.Baslik;
            }

            if (!string.IsNullOrEmpty(pdfUrl))
            {
                try
                {
                    var parameters = new Dictionary<string, object>
                    {
                        { "PdfUrl", pdfUrl },
                        { "DosyaAdi", dosyaAdi },
                        { "Baslik", baslik }
                    };

                    await Shell.Current.GoToAsync($"PdfViewer", parameters);
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Hata", "PDF görüntülenirken bir hata oluştu: " + ex.Message, "Tamam");
                }
            }
        }
    }
} 