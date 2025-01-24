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

		BindingContext = viewModel;
}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		_viewModel.LoadDataCommand.Execute(null);

		try
		{
			if (!_viewModel.IsBusy)
			{
				_viewModel.LoadData();
			}
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine($"OnAppearing Error: {ex.Message}");
		}

	}
}