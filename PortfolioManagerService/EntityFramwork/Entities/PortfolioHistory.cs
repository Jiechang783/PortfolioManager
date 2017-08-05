using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
   public class PortfolioHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? Id { get; set; }

        [Required]
        public Int32? PortfolioId {
            get;
            set;
        }

        [Required]
        public DateTime Date
        {
            get;
            set;
        }

        [Required]
        public Double PNL {
            get;
            set;
        }


    }
}
