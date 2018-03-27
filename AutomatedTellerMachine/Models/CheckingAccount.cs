using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"\d{6,10}", ErrorMessage ="Account # must be between 6 and 10.")]
        [Display(Name="Account #")]        
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name ="Fist Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        public string Name {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        //a reference to the user that holds this account. 
        //This will be automatically implemented with a foreign key that reference the user table in the database
        //virtual property allows it to be overridden by the framework with a mechanism that supports lazy loading of this related object
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}