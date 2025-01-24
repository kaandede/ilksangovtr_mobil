using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Services;
using System.Diagnostics;
using System.Text.Json;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthService _authService;
        private readonly IServiceProvider _serviceProvider;

        public LoginViewModel(AuthService authService, IServiceProvider serviceProvider)
        {
            _authService = authService;
            _serviceProvider = serviceProvider;
        }

        [ObservableProperty]
        private string tcKimlikNo;

        [ObservableProperty]
        private string sifre;

        [ObservableProperty]
        private bool beniHatirla;

        [ObservableProperty]
        private bool isBusy;

        public bool IsNotBusy => !IsBusy;

        [RelayCommand]
        private async Task SifremiUnuttum()
        {
            // Şifremi unuttum sayfasına yönlendir
            await Shell.Current.DisplayAlert("Bilgi", "Şifre yenileme için İLKSAN ile iletişime geçiniz.", "Tamam");
        }

        private async Task<UserInfo> GetUserInfo(string tcKimlikNo, string sifre)
        {
            // TODO: Gerçek API entegrasyonu yapılacak
            // Şimdilik test verisi dönüyoruz
            await Task.Delay(1000); // API çağrısı simülasyonu

            if (tcKimlikNo == "12345678901" && sifre == "123456")
            {
                return new UserInfo
                {
                    TcKimlikNo = tcKimlikNo,
                    Ad = "Kaan",
                    Soyad = "DEDE",
                    UyeKodu = "123456",
                    Email = "kaan.dede@example.com",
                    Telefon = "5551234567",
                    Adres = "Ankara"
                };
            }

            return null;
        }

        public async Task CheckSavedCredentials()
        {
            try
            {
                var rememberMe = Preferences.Get("RememberMe", false);
                if (rememberMe)
                {
                    var savedTcKimlikNo = Preferences.Get("SavedTcKimlikNo", string.Empty);
                    var savedPassword = await SecureStorage.GetAsync("SavedPassword");

                    if (!string.IsNullOrEmpty(savedTcKimlikNo) && !string.IsNullOrEmpty(savedPassword))
                    {
                        TcKimlikNo = savedTcKimlikNo;
                        Sifre = savedPassword;
                        BeniHatirla = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CheckSavedCredentials Error: {ex.Message}");
            }
        }

        private async Task SaveUserInfo(UserInfo userInfo)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(userInfo);
                await SecureStorage.SetAsync("UserInfo", jsonString);
                Preferences.Set("IsLoggedIn", true);

                if (BeniHatirla)
                {
                    Preferences.Set("RememberMe", true);
                    Preferences.Set("SavedTcKimlikNo", TcKimlikNo);
                    await SecureStorage.SetAsync("SavedPassword", Sifre);
                }
                else
                {
                    // Beni hatırla seçili değilse kayıtlı bilgileri temizle
                    Preferences.Remove("RememberMe");
                    Preferences.Remove("SavedTcKimlikNo");
                    await SecureStorage.SetAsync("SavedPassword", string.Empty);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SaveUserInfo Error: {ex.Message}");
                throw;
            }
        }

        public async Task Login()
        {
            try
            {
                if (string.IsNullOrEmpty(TcKimlikNo) || string.IsNullOrEmpty(Sifre))
                {
                    await Shell.Current.DisplayAlert("Uyarı", "TC Kimlik No ve Şifre alanları boş bırakılamaz.", "Tamam");
                    return;
                }

                bool loginSuccess = await _authService.Login(TcKimlikNo, Sifre);

                if (loginSuccess)
                {
                    var userInfo = await GetUserInfo(TcKimlikNo, Sifre);
                    if (userInfo != null)
                    {
                        await SaveUserInfo(userInfo);
                        
                        // Beni hatırla seçeneği işlemleri
                        if (BeniHatirla)
                        {
                            Preferences.Set("RememberMe", true);
                            Preferences.Set("SavedTcKimlikNo", TcKimlikNo);
                            await SecureStorage.SetAsync("SavedPassword", Sifre);
                        }

                        Application.Current.MainPage = new AppShell(_authService, _serviceProvider);
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Hata", "TC Kimlik No veya Şifre hatalı.", "Tamam");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Login Error: {ex.Message}");
                await Shell.Current.DisplayAlert("Hata", "Giriş yapılırken bir hata oluştu.", "Tamam");
            }
        }
    }
} 