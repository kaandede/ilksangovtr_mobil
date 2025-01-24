using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ilksangovtr_mobil.Models;
using ilksangovtr_mobil.Services;
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

        private async Task SaveUserInfo(UserInfo userInfo)
        {
            var jsonString = JsonSerializer.Serialize(userInfo);
            await SecureStorage.SetAsync("UserInfo", jsonString);
            Preferences.Set("IsLoggedIn", true);
        }

        public async Task CheckSavedCredentials()
        {
            if (Preferences.Get("RememberMe", false))
            {
                TcKimlikNo = Preferences.Get("SavedTcKimlikNo", string.Empty);
                Sifre = await SecureStorage.GetAsync("SavedPassword");
                BeniHatirla = true;

                if (!string.IsNullOrEmpty(TcKimlikNo) && !string.IsNullOrEmpty(Sifre))
                {
                    await Login();
                }
            }
        }

        public async Task Login()
        {
            try
            {
                IsBusy = true;

                if (string.IsNullOrEmpty(TcKimlikNo) || string.IsNullOrEmpty(Sifre))
                {
                    await Shell.Current.DisplayAlert("Uyarı", "TC Kimlik No ve Şifre alanları boş bırakılamaz.", "Tamam");
                    return;
                }

                // Kullanıcı bilgilerini al
                var userInfo = await GetUserInfo(TcKimlikNo, Sifre);

                if (userInfo != null)
                {
                    // Kullanıcı bilgilerini kaydet
                    await SaveUserInfo(userInfo);

                    if (BeniHatirla)
                    {
                        // Beni hatırla seçeneği için bilgileri kaydet
                        Preferences.Set("RememberMe", true);
                        Preferences.Set("SavedTcKimlikNo", TcKimlikNo);
                        await SecureStorage.SetAsync("SavedPassword", Sifre);
                    }

                    // Ana sayfaya yönlendir
                    Application.Current.MainPage = new AppShell(_authService, _serviceProvider);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Hata", "TC Kimlik No veya Şifre hatalı.", "Tamam");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Hata", "Giriş yapılırken bir hata oluştu: " + ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
} 