using System.ComponentModel.DataAnnotations;

namespace DergiOrtak.ViewModels
{
    public class SayiViewModel
    {
        public int Id { get; set; }

        [Required]
        public int? DergiId { get; set; }

        [Required]
        public int No { get; set; }

        [Required]
        public DateTime YayinTarihi { get; set; }
    }
}