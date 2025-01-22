using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class SifirAracKampanya : ContentPage
{
    private readonly SifirAracKampanyaViewModel _viewModel;

    public SifirAracKampanya(SifirAracKampanyaViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadDataCommand.Execute(null);
    }
} 