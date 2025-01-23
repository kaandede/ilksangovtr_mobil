using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class Kampanyalar : ContentPage
{
    private KampanyalarViewModel _viewModel;

    public Kampanyalar()
    {
        InitializeComponent();
        _viewModel = new KampanyalarViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadKampanyalarCommand.Execute(null);
    }

    private async void OnKampanyaSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Kampanya kampanya)
        {
            await _viewModel.KampanyaDetailCommand.ExecuteAsync(kampanya);
        }
    }
} 