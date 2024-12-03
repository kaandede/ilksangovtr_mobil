using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ilksangovtr_mobil
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          
        }

        protected override void OnStop()
        {
            // Gereksiz referansları temizleyin
            // Örneğin:
            // - Açık olan dialog ve progress bar'ları kapatın
            // - Gereksiz bağlantıları sonlandırın

            base.OnStop();
        }

        // Gerekirse diğer lifecycle metodları
        protected override void OnDestroy()
        {
            // Ek temizlik işlemleri
            base.OnDestroy();
        }
    }
}
