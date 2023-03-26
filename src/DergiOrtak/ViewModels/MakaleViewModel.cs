using System.ComponentModel.DataAnnotations;

namespace DergiOrtak.ViewModels
{
    public class MakaleViewModel
    {
        public int Id { get; set; }

        [Required]
        public int SayiId { get; set; }

        [Required]
        public string? Baslik { get; set; }

        [Required]
        public string? Ozet { get; set; }

        [Required]
        public string? Icerigi { get; set; }
    }
}