using ilksangovtr_mobil.Models;

namespace ilksangovtr_mobil.Views;

public partial class AracKampanya : ContentPage
{
    AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();
    public AracKampanya(AnaSayfaViewModel anaSayfaViewModel)
	{
		InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }
    private void back_Anasayfa_Arackampanya(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("///AnaSayfa");
    }

    private void OnArackSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1) // Seçim yapýldýysa
        {
            string selectedItem = (string)picker.SelectedItem;

        }
    }

    private void tapped_ikincelArac_Kampanya(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new IkinciElAracKampanya(anaSayfaViewModel));
    }
}