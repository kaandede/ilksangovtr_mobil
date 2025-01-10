using ilksangovtr_mobil.Models;


namespace ilksangovtr_mobil.Views;

public partial class AnaSayfa : ContentPage
{
    AnaSayfaViewModel anaSayfaViewModel = new AnaSayfaViewModel();
    public AnaSayfa(AnaSayfaViewModel anaSayfaViewModel)
    {
        InitializeComponent();
        BindingContext = anaSayfaViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Ana Sayfa'ya geri dönüldüðünde gerekli iþlemleri burada yapabilirsiniz
        Console.WriteLine("Ana Sayfa yeniden yüklendi!");
    }
    private async void Bildirimler_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AnaSayfa/Bildirimler", false);
    }

    private async void Click_SosyalYardimlar(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(SosyalYardimlar));
    } 
    private async void Click_AracKampanya(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(AracKampanya));
    }

  
}