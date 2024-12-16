using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilksangovtr_mobil.Models
{

    public partial class AnaSayfaViewModel : ObservableObject
    {
        public ObservableCollection<CarouselItem> CarouselItems { get; set; } = new();
        public ObservableCollection<DuyuruItem> DuyuruItems { get; set; } = new();
        public ObservableCollection<BildirimItem> BildirimItems { get; set; } = new();
        public ObservableCollection<MessageItem> MessageItems { get; set; } = new();
        public ObservableCollection<AidatBilgilerim> AidatBilgilerims { get; set; } = new();




        public AnaSayfaViewModel() 
        {
            CarouselItems.Add(new CarouselItem()
            {
                Title = "Başlık 1",
                Description= "Açıklama 2",
                Image = "back4.png"
            });
            CarouselItems.Add(new CarouselItem()
            {
                Title = "Başlık 2",
                Description = "Açıklama 2",
                Image = "back2.png"
            });




            DateTime duyuru_date = DateTime.Now;
            string shortDate = duyuru_date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            DuyuruItems.Add(new DuyuruItem()
            {
                Duyuru_Title = "Acıbadem Sağlık Grubundan İLKSAN Üyelerine Özel İndirimler",
                Duyuru_date = shortDate,
                Duyuru_Image = "duyuru.png"
            });  
            DuyuruItems.Add(new DuyuruItem()
            {
                Duyuru_Title = "Klinik 23 Nİisan Ağız ve Diş Sağlığı Polikliniği'nden Üyelerimize Özel İndirimler",
                Duyuru_date = shortDate,
                Duyuru_Image = "duyuru.png"
            });   
            DuyuruItems.Add(new DuyuruItem()
            {
                Duyuru_Title = "Ankara Özel Dentapros Ağız ve Diş Sağlığı Plokliniği'den Üyelerimize Özel İndirimler",
                Duyuru_date = shortDate,
                Duyuru_Image = "duyuru.png"
            }); 
            DuyuruItems.Add(new DuyuruItem()
            {
                Duyuru_Title = "İstanbul 360 Ağız ve Diş Sağlığı Plokliniği'den Üyelerimize Özel İndirimler",
                Duyuru_date = shortDate,
                Duyuru_Image = "duyuru.png"
            });



            DateTime bildirim_date = DateTime.Now;
            string bildirim_short_Date = bildirim_date.ToString("dd/MM", CultureInfo.InvariantCulture);

            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza iade edildi."
            });

            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri2",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir."
            });

            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri3",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde."
            });


            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri4",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza."
            });

            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri5",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza."
            });


            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri6",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza."
            });


            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri7",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza."
            });


            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri8",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza."
            });


            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri9",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza."
            });


            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri10",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza."
            });

            BildirimItems.Add(new BildirimItem()
            {
                Bildirim_Title = "Transfer ve Döviz İşlemleri11",
                Bildirim_date = bildirim_short_Date,
                Bildirim_Description = "0470 ile biten ilksan mobil uygulama ile hesap kodunuza ait aidat ödemesi başarılı bir şekilde tarafınıza."
            });




            DateTime message_date = DateTime.Now;
            string message_short_Date = message_date.ToString("dd/MM", CultureInfo.InvariantCulture);


            MessageItems.Add(new MessageItem()
            {
                Message_Title = "Transfer ve Döviz İşlemleri1",
                Message_date = message_short_Date,
           
            }); 
            MessageItems.Add(new MessageItem()
            {
                Message_Title = "Transfer ve Döviz İşlemleri2",
                Message_date = message_short_Date,
           
            });

            MessageItems.Add(new MessageItem()
            {
                Message_Title = "Transfer ve Döviz İşlemleri3",
                Message_date = message_short_Date,

            });
            MessageItems.Add(new MessageItem()
            {
                Message_Title = "Transfer ve Döviz İşlemleri4",
                Message_date = message_short_Date,

            });
            MessageItems.Add(new MessageItem()
            {
                Message_Title = "Transfer ve Döviz İşlemleri5",
                Message_date = message_short_Date,

            });

            AidatBilgilerims.Add(new AidatBilgilerim()
            {
                ToplamOdenenAidatTutari = ": 23.992,73 ₺",
                ToplamMahsupAidatTutari = ": 0 ₺",
                ToplamTutar = ": 23.992,73 ₺"
            });
        }
    }
}
