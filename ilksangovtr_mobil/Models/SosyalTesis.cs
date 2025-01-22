namespace ilksangovtr_mobil.Models
{
    public class SosyalTesis
    {
        public string Id { get; set; }
        public string Ad { get; set; }
        public string TesisTipi { get; set; }
        public string Konum { get; set; }
        public string ImageUrl { get; set; }
        public int OdaSayisi { get; set; }
        public string Aciklama { get; set; }
        public List<string> Ozellikler { get; set; }
        public string IletisimTelefon { get; set; }
        public string IletisimEmail { get; set; }
        public string WebSiteUrl { get; set; }
    }
} 