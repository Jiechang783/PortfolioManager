using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.Entities
{
    public class Bond
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Isin { get; set; }

        [Required]
        public string Issuer { get; set; }

        [Required]
        public double Coupon { get; set; }

        [Required]
        public string MaturityMonth { get; set; }

        [Required]
        public int MaturityYear { get; set; }
    }
}
