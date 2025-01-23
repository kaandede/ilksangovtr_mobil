namespace ilksangovtr_mobil.Models
{
    public class Kampanya
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Category { get; set; }
        public string? ValidUntil { get; set; }
        public string? DetailUrl { get; set; }
        public bool IsFeatured { get; set; }
        public string ButtonText { get; set; } = "DETAYLI BİLGİ";
    }
} 