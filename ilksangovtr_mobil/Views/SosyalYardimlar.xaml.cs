using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class SosyalYardimlar : ContentPage
{
    private readonly SosyalYardimlarViewModel _viewModel;

    public SosyalYardimlar(SosyalYardimlarViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            string selectedItem = (string)picker.SelectedItem;
        }
    }

    private async void YeniSosyalYardim(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(YeniSosyalYardimBasvurusu));
    }
}