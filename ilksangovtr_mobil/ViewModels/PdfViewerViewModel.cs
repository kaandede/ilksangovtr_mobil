using CommunityToolkit.Mvvm.ComponentModel;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class PdfViewerViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _pdfUrl;

        [ObservableProperty]
        private string _dosyaAdi;

        [ObservableProperty]
        private string _baslik;

        [ObservableProperty]
        private bool _isLoading = true;

        public bool IsNotLoading => !IsLoading;

        public PdfViewerViewModel()
        {
            // PDF yüklenirken loading göster
            Task.Delay(2000).ContinueWith(_ =>
            {
                IsLoading = false;
                OnPropertyChanged(nameof(IsNotLoading));
            });
        }
    }
} 