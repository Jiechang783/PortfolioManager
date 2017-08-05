using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
   public class Portfolio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? PortfolioId { get; set; }

        [Required]

        public string Name {
            get;
            set;
        }

        public virtual ICollection<Position> positions {
            get;
            set;
        }
    }
}
