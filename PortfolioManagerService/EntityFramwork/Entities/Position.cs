using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
   public class Position
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? PositionId { get; set; }

        [Required]
        public Int32 Quantity {
            get;
            set;
        }

        [Required]
        public Decimal Price {
            get;
            set;
        }

        [Required]
        public string Isin { get; set; }

        [ForeignKey("Isin")]
        public virtual Security security
        {
            get;
            set;
        }
    }
}
