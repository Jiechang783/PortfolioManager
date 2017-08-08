using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.Entities
{
    public class PriceHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Isin { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal OfferPrice { get; set; }

        [Required]
        public decimal BidPrice { get; set; }

        public string Type { get; set; }
    }
}
