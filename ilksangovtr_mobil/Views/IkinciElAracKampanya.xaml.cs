using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class IkinciElAracKampanya : ContentPage
{
    private readonly IkinciElAracKampanyaViewModel _viewModel;

    public IkinciElAracKampanya(IkinciElAracKampanyaViewModel viewModel)
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