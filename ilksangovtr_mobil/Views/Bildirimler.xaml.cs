using DevExpress.Maui.Controls;
using ilksangovtr_mobil.ViewModels;

namespace ilksangovtr_mobil.Views;

public partial class Bildirimler : ContentPage
{
	private readonly BildirimlerViewModel _viewModel;

	public Bildirimler(BildirimlerViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		try
		{
			if (!_viewModel.IsBusy)
			{
				await _viewModel.LoadDataCommand.ExecuteAsync(null);
			}
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine($"OnAppearing Error: {ex.Message}");
		}
	}
}