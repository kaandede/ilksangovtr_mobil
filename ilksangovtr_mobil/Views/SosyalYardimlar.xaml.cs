using ilksangovtr_mobil.Models;
using Syncfusion.Maui.Core.Carousel;

namespace ilksangovtr_mobil.Views;

public partial class SosyalYardimlar : ContentPage
{
    AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();

    public SosyalYardimlar(AnaSayfaViewModel anaSayfaViewModel)
    {
        InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }

    private void back_Anasayfa_SoyalYardim(object sender, EventArgs e)
    {
         Shell.Current.GoToAsync("///AnaSayfa");
    }

    private void YeniSosyalYardim(object sender, EventArgs e)
    {
        Navigation.PushAsync(new YeniSosyalYardimBasvurusu(anaSayfaViewModel));
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1) // Se�im yap�ld�ysa
        {
            string selectedItem = (string)picker.SelectedItem;

        }
    }
}