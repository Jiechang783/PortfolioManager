using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
   public class PriceHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? Id { get; set; }

        [Required]
        public string Isin {
            get;
            set;
        }

        [Required]
        public DateTime Date {
            get;
            set;
        }

        [Required]
        public decimal Price
        {
            get;
            set;
        }



    }
}
