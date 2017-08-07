using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
   public class Industry
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndustryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Stock> positions { get; set; }
    }
}
