using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using System.Collections.ObjectModel;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class OtellerKonukevleriViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<SosyalTesis> _tesisler;

        public OtellerKonukevleriViewModel()
        {
            LoadTesisler();
        }

        private void LoadTesisler()
        {
            var tesisListesi = new List<SosyalTesis>
            {
                new SosyalTesis
                {
                    Id = "1",
                    Ad = "İLKSAN Ankara Konukevi",
                    TesisTipi = "Konukevi",
                    Konum = "Ankara, Çankaya",
                    ImageUrl = "back16.png",
                    OdaSayisi = 44,
                    Aciklama = "Modern mimarisi ve merkezi konumuyla hizmetinizde",
                    IletisimTelefon = "0312 425 09 09",
                    IletisimEmail = "ankarakonukevi@ilksan.gov.tr"
                },
                new SosyalTesis
                {
                    Id = "2",
                    Ad = "İLKSAN İzmir Konukevi",
                    TesisTipi = "Konukevi",
                    Konum = "İzmir, Karşıyaka",
                    ImageUrl = "izmir_konukevi.jpg",
                    OdaSayisi = 36,
                    Aciklama = "Deniz manzaralı konforlu odalar",
                    IletisimTelefon = "0232 368 09 09",
                    IletisimEmail = "izmirkonukevi@ilksan.gov.tr"
                },
                new SosyalTesis
                {
                    Id = "3",
                    Ad = "İLKSAN Antalya Oteli",
                    TesisTipi = "Otel",
                    Konum = "Antalya, Konyaaltı",
                    ImageUrl = "antalya_otel.jpg",
                    OdaSayisi = 82,
                    Aciklama = "5 yıldızlı konfor ve hizmet kalitesi",
                    IletisimTelefon = "0242 230 09 09",
                    IletisimEmail = "antalyaotel@ilksan.gov.tr"
                }
            };

            Tesisler = new ObservableCollection<SosyalTesis>(tesisListesi);
        }

        [RelayCommand]
        private async Task TesisDetailAsync(SosyalTesis tesis)
        {
            if (tesis == null)
                return;

            var parameters = new Dictionary<string, object>
            {
                { "TesisId", tesis.Id }
            };

            await Shell.Current.GoToAsync($"TesisDetail", parameters);
        }
    }
} 