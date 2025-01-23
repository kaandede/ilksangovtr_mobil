using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class Duyurular : ContentPage
{
    public Duyurular(DuyurularViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
} 