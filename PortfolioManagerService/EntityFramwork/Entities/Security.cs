using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
   public  class Security
    {
        [Key]
        public string Isin { get; set; }

        [Required]
        public string Name {
            get;
            set;
        }

        [Required]
        public decimal Price
        {
            get;
            set;
        }

        [Required]
        public string Type {
            get;
            set;
        }


    }
}
