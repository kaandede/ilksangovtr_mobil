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

            // İstenilen formatta tarihi string olarak al
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

        }
    }
}
