using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Services;
using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly AuthService _authService;
        private readonly IServiceProvider _serviceProvider;

        public UserViewModel(AuthService authService, IServiceProvider serviceProvider)
        {
            _authService = authService;
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        private async Task GuvenliCikis()
        {
            try
            {
                bool onay = await Application.Current.MainPage.DisplayAlert(
                    "Güvenli Çıkış", 
                    "Oturumunuzu sonlandırmak istediğinizden emin misiniz?", 
                    "Evet, Çıkış Yap", 
                    "İptal");

                if (onay)
                {
                    IsBusy = true;

                    // AuthService üzerinden çıkış yap
                    await _authService.LogOut();

                    // Login sayfasına yönlendir
                    var loginViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
                    Application.Current.MainPage = new Login(loginViewModel, _authService, _serviceProvider);

                    // Çıkış mesajını göster
                    await Application.Current.MainPage.DisplayAlert(
                        "Güvenli Çıkış", 
                        "Oturumunuz güvenli bir şekilde sonlandırıldı.", 
                        "Tamam");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Hata", 
                    "Çıkış yapılırken bir hata oluştu: " + ex.Message, 
                    "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ObservableProperty]
        private bool isBusy;
    }
} 