using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
   public  class Stock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Isin { get; set; }

        [Required]
        public string Name {
            get;
            set;
        }

        [Required]
        public string Symbol
        {
            get;
            set;
        }

        [Required]
        public decimal LastSale
        {
            get;
            set;
        }

        [Required]
        public decimal MarketCap
        {
            get;
            set;
        }

        [Required]
        public DateTime IPOyear
        {
            get;
            set;
        }

        [Required]
        public string Sector
        {
            get;
            set;
        }

        [Required]
        public string industry
        {
            get;
            set;
        }

        [Required]
        public string SummaryQuote
        {
            get;
            set;
        }

        [Required]
        public string Address    //NASDAQ,NYSE,ARCA
        {
            get;
            set;
        }

    }
}
