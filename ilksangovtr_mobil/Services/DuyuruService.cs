using ilksangovtr_mobil.Models;
using System.Globalization;
using System.Threading.Tasks;

namespace ilksangovtr_mobil.Services
{
    public class DuyuruService
    {
        private static readonly CultureInfo trCulture = new CultureInfo("tr-TR");
        private static readonly List<DuyuruItem> _duyurular = new()
        {
            new DuyuruItem
            {
                Duyuru_Title = "Acıbadem Sağlık Grubundan İLKSAN Üyelerine Özel İndirimler",
                Duyuru_date = DateTime.Now.ToString("dd/MM/yyyy", trCulture),
                Duyuru_Description = "İLKSAN üyelerine özel Acıbadem Sağlık Grubu'nda geçerli indirimler hakkında detaylı bilgi için tıklayınız.",
                Duyuru_Url = "https://www.ilksan.gov.tr/duyurular/acibadem-indirim"
            },
            new DuyuruItem
            {
                Duyuru_Title = "2024 Yılı Sosyal Yardım Başvuruları Başladı",
                Duyuru_date = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", trCulture),
                Duyuru_Description = "2024 yılı sosyal yardım başvuruları başlamıştır. Son başvuru tarihi 31 Mart 2024'tür.",
                Duyuru_Url = "https://www.ilksan.gov.tr/duyurular/sosyal-yardim-2024"
            },
            new DuyuruItem
            {
                Duyuru_Title = "2024 2.Yılı Sosyal Yardım Başvuruları Başladı",
                Duyuru_date = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", trCulture),
                Duyuru_Description = "2024 yılı sosyal yardım başvuruları başlamıştır. Son başvuru tarihi 31 Mart 2024'tür.",
                Duyuru_Url = "https://www.ilksan.gov.tr/duyurular/sosyal-yardim-2024"
            },
            new DuyuruItem
            {
                Duyuru_Title = "2024 3.Yılı Sosyal Yardım Başvuruları Başladı",
                Duyuru_date = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy", trCulture),
                Duyuru_Description = "2024 yılı sosyal yardım başvuruları başlamıştır. Son başvuru tarihi 31 Mart 2024'tür.",
                Duyuru_Url = "https://www.ilksan.gov.tr/duyurular/sosyal-yardim-2024"
            }
            // ... diğer duyurular
        };

        public List<DuyuruItem> GetDuyurular(int? limit = null)
        {
            var duyurular = _duyurular.OrderByDescending(d => DateTime.ParseExact(d.Duyuru_date, "dd/MM/yyyy", trCulture));
            return limit.HasValue ? duyurular.Take(limit.Value).ToList() : duyurular.ToList();
        }
    }
} 