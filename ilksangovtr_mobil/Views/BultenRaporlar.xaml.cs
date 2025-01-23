using ilksangovtr_mobil.ViewModels;
using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class BultenRaporlar : ContentPage
{
    private BultenRaporlarViewModel _viewModel;

    public BultenRaporlar()
    {
        InitializeComponent();
        _viewModel = new BultenRaporlarViewModel();
        BindingContext = _viewModel;
    }

    private async void OnBultenSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Bulten bulten)
        {
            // Seçimi temizle
            ((CollectionView)sender).SelectedItem = null;

            try
            {
                await _viewModel.PdfGoruntuleCommand.ExecuteAsync(bulten);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", "PDF görüntülenirken bir hata oluştu: " + ex.Message, "Tamam");
            }
        }
    }

    private async void OnRaporSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Rapor rapor)
        {
            // Seçimi temizle
            ((CollectionView)sender).SelectedItem = null;

            try
            {
                await _viewModel.PdfGoruntuleCommand.ExecuteAsync(rapor);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", "PDF görüntülenirken bir hata oluştu: " + ex.Message, "Tamam");
            }
        }
    }
} 