using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EktivaBankNetApp.Models
{
    public class Account
    {
        [Range(0, 1000000)]
        public double Balance { get; set; }
        public string Tag { get; set; }
        public int Id { get; set; }

        [DisplayName("Account No")]
        public int AccountNumber { get; set; }
        public int CustomerId { get; set; }

        public string AccountType { get; set; }

        public virtual int yearTerm { get; set; }

        [DataType(DataType.Date)]
        public DateTime openDate { get; set; }
        [DisplayName("Interest")]
        public virtual double interestRate { get; set; }

    }
}
