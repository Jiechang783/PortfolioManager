using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork
{
  public  class Future
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FutureId { get; set; }
        [Required]
        public string Isin { get; set; }

        public string Exch { get; set; }

        public string Sym { get; set; }

        public string Desc { get; set; }

        public string SecTyp { get; set; }

        public DateTime MatDt { get; set; }

        public Int64 UOMQty { get; set; }

        public string ID { get; set; }
    }
}
