using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

[QueryProperty(nameof(Kampanya), "Kampanya")]
public partial class KampanyaDetail : ContentPage
{
    private KampanyaDetailViewModel _viewModel;

    public Kampanya Kampanya { get; set; }

    public KampanyaDetail()
    {
        InitializeComponent();
        _viewModel = new KampanyaDetailViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.Kampanya = Kampanya;
    }
} 