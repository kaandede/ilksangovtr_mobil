namespace ilksangovtr_mobil.Views;

public partial class Aidat : ContentPage
{
	public Aidat()
	{
		InitializeComponent();
	}

    private void Bildirim_aidata_git(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Bildirimler());
    }

}