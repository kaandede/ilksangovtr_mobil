using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

[QueryProperty(nameof(PdfUrl), "PdfUrl")]
[QueryProperty(nameof(DosyaAdi), "DosyaAdi")]
[QueryProperty(nameof(Baslik), "Baslik")]
public partial class PdfViewer : ContentPage
{
    public string PdfUrl { get; set; }
    public string DosyaAdi { get; set; }
    public string Baslik { get; set; }

    public PdfViewer()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = new PdfViewerViewModel
        {
            PdfUrl = this.PdfUrl,
            DosyaAdi = this.DosyaAdi,
            Baslik = this.Baslik
        };
        BindingContext = viewModel;
    }
} 