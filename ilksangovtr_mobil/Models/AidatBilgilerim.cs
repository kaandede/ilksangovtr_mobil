using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ilksangovtr_mobil.Models
{
    public class AidatBilgilerim
    {
        public AidatBilgilerim() { }

        public string? ToplamOdenenAidatTutari { get; set; }
        public string? ToplamMahsupAidatTutari { get; set; }
        public string? ToplamTutar { get; set; }
        public string? Tutar { get; set; }
        public string? Kurum { get; set; }
        public string? OdenenTutar { get; set; }
        public string? Odenen { get; set; }
        public string? Kalan { get; set; }
        public string? Durum { get; set; }
        public string? AidatTarih { get; set; }
        public string? AidatYil{ get; set; }
        public string? AidatAy { get; set; }


    }
}
