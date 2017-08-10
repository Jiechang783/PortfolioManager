using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.Entities
{
    public class Portfolio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PortfolioId { get; set; }

        [Required]
        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<Position> positions { get; set; }
    }
}
