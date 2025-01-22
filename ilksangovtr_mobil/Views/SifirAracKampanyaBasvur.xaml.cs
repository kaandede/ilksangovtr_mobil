using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class SifirAracKampanyaBasvur : ContentPage
{
    private readonly SifirAracKampanyaBasvurViewModel _viewModel;

    public SifirAracKampanyaBasvur(SifirAracKampanyaBasvurViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
} 