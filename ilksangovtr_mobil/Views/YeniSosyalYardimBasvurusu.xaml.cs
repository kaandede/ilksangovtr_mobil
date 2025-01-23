using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class YeniSosyalYardimBasvurusu : ContentPage
{
    private readonly YeniSosyalYardimBasvurusuViewModel _viewModel;

    public YeniSosyalYardimBasvurusu(YeniSosyalYardimBasvurusuViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}