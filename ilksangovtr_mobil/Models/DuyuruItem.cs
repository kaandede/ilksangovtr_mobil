using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilksangovtr_mobil.Models
{
    public class DuyuruItem
    {
        public string Duyuru_Title { get; set; }
        public string Duyuru_date { get; set; }
        public string Duyuru_Description { get; set; }
        public string Duyuru_Image { get; set; }
        public string Duyuru_Url { get; set; }
    }
}
