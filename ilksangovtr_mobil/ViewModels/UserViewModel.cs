using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ilksangovtr_mobil.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task GuvenliCikis()
        {
            bool onay = await Shell.Current.DisplayAlert(
                "Güvenli Çıkış", 
                "Oturumunuzu sonlandırmak istediğinizden emin misiniz?", 
                "Evet, Çıkış Yap", 
                "İptal");

            if (onay)
            {
                try
                {
                    // Yükleniyor göstergesi
                    IsBusy = true;

                    // Oturum temizleme işlemleri
                    await Task.Run(() =>
                    {
                        // Token temizle
                        Preferences.Remove("AuthToken");
                        // Kullanıcı bilgilerini temizle
                        Preferences.Remove("UserInfo");
                        // Diğer hassas verileri temizle
                        SecureStorage.RemoveAll();
                    });

                    // Ana sayfaya yönlendir
                    await Shell.Current.GoToAsync("//Login");

                    // Başarılı çıkış mesajı
                    await Shell.Current.DisplayAlert(
                        "Güvenli Çıkış", 
                        "Oturumunuz güvenli bir şekilde sonlandırıldı.", 
                        "Tamam");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert(
                        "Hata", 
                        "Çıkış yapılırken bir hata oluştu. Lütfen tekrar deneyin.", 
                        "Tamam");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        [ObservableProperty]
        private bool isBusy;
    }
} 