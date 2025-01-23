using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class BildirimDetail : ContentPage
{
    private readonly BildirimDetailViewModel _viewModel;

    public BildirimDetail(BildirimDetailViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
} 