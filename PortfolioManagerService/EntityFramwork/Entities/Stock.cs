using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramwork.Entities
{
    public class Stock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Isin { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Symbol { get; set; }


        public decimal LastSale { get; set; }

   
        public string MarketCap { get; set; }

    
        public DateTime IPOyear { get; set; }

        [Required]
        public string Sector { get; set; }

        [Required]
        public string industry { get; set; }

    
        public string SummaryQuote { get; set; }

        //NASDAQ,NYSE,ARCA
        [Required]
        public string Address { get; set; }
    }
}
