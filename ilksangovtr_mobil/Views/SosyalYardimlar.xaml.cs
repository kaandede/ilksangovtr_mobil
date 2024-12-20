using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class SosyalYardimlar : ContentPage
{

    public SosyalYardimlar(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;       
    }

    async void back_Anasayfa_SoyalYardim(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1) // Seçim yapýldýysa
        {
            string selectedItem = (string)picker.SelectedItem;
         
        }
    }
}