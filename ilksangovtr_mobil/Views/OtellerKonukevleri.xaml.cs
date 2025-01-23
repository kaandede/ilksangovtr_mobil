using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class OtellerKonukevleri : ContentPage
{
    public OtellerKonukevleri()
    {
        InitializeComponent();
        BindingContext = new OtellerKonukevleriViewModel();
    }

    private void OnTesisSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is SosyalTesis selectedTesis)
        {
            ((CollectionView)sender).SelectedItem = null;
            var viewModel = (OtellerKonukevleriViewModel)BindingContext;
            viewModel.TesisDetailCommand.Execute(selectedTesis);
        }
    }
} 