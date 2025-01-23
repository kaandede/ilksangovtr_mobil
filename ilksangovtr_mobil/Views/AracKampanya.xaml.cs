using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class AracKampanya : ContentPage
{
    private readonly AracKampanyaViewModel _viewModel;

    public AracKampanya(AracKampanyaViewModel viewModel)
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