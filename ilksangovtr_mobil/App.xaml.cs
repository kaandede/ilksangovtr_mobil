using ilksangovtr_mobil.Views;

namespace ilksangovtr_mobil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzYwNjk4M0AzMjM3MmUzMDJlMzBlQlN2RWtKMHE3YnhtcS9lWThNeGdzMzdCbDlrWDNGbjJHQ3hTaTJDN3RnPQ==\r\n\r\n");

            MainPage = new AppShell();
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
#if __ANDROID__
                 handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }
    }
}
