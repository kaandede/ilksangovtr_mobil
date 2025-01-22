namespace ilksangovtr_mobil.Views;

public partial class ChangePasswordPage : ContentPage
{
	public ChangePasswordPage()
	{
		InitializeComponent();
	}

	private async void OnCancelClicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

	private async void OnChangePasswordClicked(object sender, EventArgs e)
	{
		// Şifre değiştirme işlemleri burada yapılacak
		await Navigation.PopModalAsync();
	}

	private void OnShowPasswordClicked(object sender, EventArgs e)
	{
		var button = sender as ImageButton;
		var entry = button.Parent.FindByName<Entry>("PasswordEntry");
		entry.IsPassword = !entry.IsPassword;
		button.Source = entry.IsPassword ? "eye_icon.png" : "eye_off_icon.png";
	}

	private void OnPasswordChanged(object sender, TextChangedEventArgs e)
	{
		var password = e.NewTextValue;
		var strength = CalculatePasswordStrength(password);
		UpdatePasswordStrengthIndicator(strength);
	}

	private int CalculatePasswordStrength(string password)
	{
		int strength = 0;
		if (string.IsNullOrEmpty(password)) return strength;

		if (password.Length >= 8) strength++;
		if (password.Any(char.IsUpper)) strength++;
		if (password.Any(char.IsLower)) strength++;
		if (password.Any(char.IsDigit)) strength++;
		if (password.Any(ch => !char.IsLetterOrDigit(ch))) strength++;

		return strength;
	}

	private void UpdatePasswordStrengthIndicator(int strength)
	{
		var strengthText = "";
		var strengthColor = "";

		switch (strength)
		{
			case 1:
				strengthText = "Çok Zayıf";
				strengthColor = "#E63950";
				break;
			case 2:
				strengthText = "Zayıf";
				strengthColor = "#F59E0B";
				break;
			case 3:
				strengthText = "Orta";
				strengthColor = "#10B981";
				break;
			case 4:
				strengthText = "Güçlü";
				strengthColor = "#0D7561";
				break;
			case 5:
				strengthText = "Çok Güçlü";
				strengthColor = "#047857";
				break;
		}

		StrengthLabel.Text = strengthText;
		StrengthLabel.TextColor = Color.FromArgb(strengthColor);

		for (int i = 0; i < 4; i++)
		{
			var border = StrengthGrid.FindByName<Border>($"Strength{i}");
			border.BackgroundColor = i < strength ? 
				Color.FromArgb(strengthColor) : 
				Color.FromArgb("#F3F7F6");
		}
	}
}