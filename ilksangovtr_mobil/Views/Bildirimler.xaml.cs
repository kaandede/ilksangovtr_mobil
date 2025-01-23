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
<<<<<<< HEAD
		BindingContext = _viewModel;
=======
		BindingContext = viewModel;
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
<<<<<<< HEAD
		_viewModel.LoadDataCommand.Execute(null);
=======
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
>>>>>>> bc064b6d546b2507753d0de211bec7e59797acfd
	}
}