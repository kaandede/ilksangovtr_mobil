using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

[QueryProperty(nameof(Duyuru), "Duyuru")]
public partial class DuyuruDetail : ContentPage
{
    public DuyuruItem Duyuru { get; set; }
    
    public DuyuruDetail()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = new DuyuruDetailViewModel { Duyuru = Duyuru };
    }
} 