using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
    public class Bonds
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Isin { get; set; }


        [Required]
        public string Issuer
        {
            get;
            set;
        }

        [Required]
        public double Coupon {
            get;
            set;
        }

        [Required]
        public string MaturityMonth
        {
            get;
            set;
        }

        [Required]
        public DateTime MaturityYear  //存数据可能有点问题
        {
            get;
            set;
        }

    }
}
