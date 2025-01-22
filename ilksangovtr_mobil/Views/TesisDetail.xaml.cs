using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

[QueryProperty(nameof(TesisId), "TesisId")]
public partial class TesisDetail : ContentPage
{
    private string tesisId;
    public string TesisId
    {
        get => tesisId;
        set
        {
            tesisId = value;
            LoadTesis(value);
        }
    }

    public TesisDetail()
    {
        InitializeComponent();
        BindingContext = new TesisDetailViewModel();
    }

    private void LoadTesis(string tesisId)
    {
        var viewModel = (TesisDetailViewModel)BindingContext;
        viewModel.LoadTesis(tesisId);
    }
} 