using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ilksangovtr_mobil.Models;
using System.Diagnostics;

namespace ilksangovtr_mobil.Services
{
    public class AuthService
    {
        public async Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                var isLoggedIn = Preferences.Get("IsLoggedIn", false);
                if (!isLoggedIn) return false;

                // Beni hatırla kontrolü
                var rememberMe = Preferences.Get("RememberMe", false);
                if (rememberMe)
                {
                    var savedTcKimlikNo = Preferences.Get("SavedTcKimlikNo", string.Empty);
                    var savedPassword = await SecureStorage.GetAsync("SavedPassword");
                    
                    if (!string.IsNullOrEmpty(savedTcKimlikNo) && !string.IsNullOrEmpty(savedPassword))
                    {
                        return true;
                    }
                }

                // Kullanıcı bilgilerini kontrol et
                var userInfoJson = await SecureStorage.GetAsync("UserInfo");
                return !string.IsNullOrEmpty(userInfoJson);
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Login(string tcKimlikNo, string sifre)
        {
            try
            {
                // TODO: Gerçek API entegrasyonu yapılacak
                await Task.Delay(1000); // API simülasyonu

                if (tcKimlikNo == "12345678901" && sifre == "123456")
                {
                    Preferences.Set("IsLoggedIn", true);
                    
                    // Kullanıcı bilgilerini oluştur ve kaydet
                    var userInfo = new UserInfo
                    {
                        TcKimlikNo = tcKimlikNo,
                        Ad = "Kaan",
                        Soyad = "DEDE",
                        UyeKodu = "123456",
                        Email = "kaan.dede@example.com",
                        Telefon = "5551234567",
                        Adres = "Ankara"
                    };

                    var jsonString = JsonSerializer.Serialize(userInfo);
                    await SecureStorage.SetAsync("UserInfo", jsonString);
                    
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Login Error: {ex.Message}");
                return false;
            }
        }

        public async Task<UserInfo> GetCurrentUser()
        {
            try
            {
                var userInfoJson = await SecureStorage.GetAsync("UserInfo");
                if (!string.IsNullOrEmpty(userInfoJson))
                {
                    return JsonSerializer.Deserialize<UserInfo>(userInfoJson);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetCurrentUser Error: {ex.Message}");
            }
            return null;
        }

        public async Task LogOut()
        {
            try
            {
                Preferences.Clear(); // Tüm preferences'ları temizle
                SecureStorage.RemoveAll(); // Tüm secure storage'ı temizle
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logout Error: {ex.Message}");
                throw;
            }
        }
    }
}
