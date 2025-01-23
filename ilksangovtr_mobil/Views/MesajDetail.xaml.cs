using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class MesajDetail : ContentPage
{
    private readonly MesajDetailViewModel _viewModel;

    public MesajDetail(MesajDetailViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
} 