namespace DergiOrtak.Entity
{
    public class Makale : EntityBase
    {
        public int SayiId { get; set; }
        public Sayi Sayi { get; set; }

        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerigi { get; set; } //html içerik
    }
}