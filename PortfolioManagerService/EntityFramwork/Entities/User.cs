using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork.Entities
{
   public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? UserId { get; set; }

        [Required]
        public string FirstName {
            get;
            set;
        }

        [Required]
        public string LastName {
            get;
            set;
        }

        public string Email {
            get;
            set;
        }

        public string telephone{
            get;
            set;
        }

        [Required]
        public string Role {
            get;
            set;
        }

        public virtual ICollection<Portfolio> portfolios
        {
            get;
            set;
        }
    }
}
