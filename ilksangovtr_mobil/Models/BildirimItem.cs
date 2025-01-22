using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilksangovtr_mobil.Models
{
    public class BildirimItem
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public bool Okundu { get; set; }
    }
}
