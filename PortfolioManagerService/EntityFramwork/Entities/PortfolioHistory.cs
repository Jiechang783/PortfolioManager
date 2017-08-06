using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.Entities
{
    public class PortfolioHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double PNL { get; set; }
    }
}
