using ilksangovtr_mobil.Models;
using System.Diagnostics;
using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class AnaSayfa : ContentPage
{
    private readonly AnaSayfaViewModel _viewModel;
    private readonly KampanyalarViewModel _kampanyalarViewModel;
    private readonly AidatViewModel _aidatViewModel;
    
    public AnaSayfa(
        AnaSayfaViewModel viewModel,
        KampanyalarViewModel kampanyalarViewModel,
        AidatViewModel aidatViewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _kampanyalarViewModel = kampanyalarViewModel;
        _aidatViewModel = aidatViewModel;

        // Tüm view model'leri ve komutları içeren anonim tip
        BindingContext = new
        {
            AidatVM = _aidatViewModel,
            KampanyalarVM = _kampanyalarViewModel,
            DuyuruItems = _viewModel.DuyuruItems,
            KullaniciSelamlama = _viewModel.KullaniciSelamlama,
            TumDuyurularCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(Duyurular))),
            DuyuruDetailCommand = new Command<DuyuruItem>(async (duyuru) => await OnDuyuruSelected(duyuru))
        };

        // KullaniciSelamlama property'sinin değişimini dinle
        _viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(AnaSayfaViewModel.KullaniciSelamlama))
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // BindingContext'i güncelle
                    BindingContext = new
                    {
                        AidatVM = _aidatViewModel,
                        KampanyalarVM = _kampanyalarViewModel,
                        DuyuruItems = _viewModel.DuyuruItems,
                        KullaniciSelamlama = _viewModel.KullaniciSelamlama,
                        TumDuyurularCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(Duyurular))),
                        DuyuruDetailCommand = new Command<DuyuruItem>(async (duyuru) => await OnDuyuruSelected(duyuru))
                    };
                });
            }
        };
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadUserInfoAsync();
    }

    private async Task OnDuyuruSelected(DuyuruItem duyuru)
    {
        if (duyuru == null) return;

        try
        {
            var parameters = new Dictionary<string, object>
            {
                { "Duyuru", duyuru }
            };
            await Shell.Current.GoToAsync($"{nameof(DuyuruDetail)}", parameters);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Navigation error: {ex.Message}");
            await Shell.Current.DisplayAlert("Hata", "Sayfa açılırken bir hata oluştu.", "Tamam");
        }
    }

    private async void OnKampanyaSelected(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Kampanya kampanya)
        {
            await _kampanyalarViewModel.KampanyaDetailCommand.ExecuteAsync(kampanya);
        }
    }
    
    private async void Bildirimler_Clicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(Bildirimler));
    }

    private async void Click_SosyalYardimlar(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(SosyalYardimlar));
    } 

    private async void Ikraz_hesaplama(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(IkrazHesaplama));
    }

    private async void Click_IkrazSigortaPoliceleri(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(IkrazSigortaPoliceleri));
    }

    private async void Click_Kampanyalar(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Kampanyalar));
    }

    private async void Click_OtellerKonukevleri(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(OtellerKonukevleri));
    }

    private async void Click_BultenRaporlar(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BultenRaporlar));
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AracKampanya));
    }
}