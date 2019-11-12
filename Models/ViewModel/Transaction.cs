using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EktivaBankNetApp.Models.ViewModel
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        //public List<Account> Accounts { get; set; }
        [DisplayName("Account")]
        public int AccFromId { get; set; }
        [DisplayName("Account")]
        public int AccToId { get; set; }

        [Range(0, 1000000)]
        public double Amount { get; set; }

        [DisplayName("Balance Before")]
        [Range(0, 1000000)]
        public double BalBefore { get; set; }

        [DisplayName("New Balance")]
        [Range(0, 1000000)]
        public double BalAfter { get; set; }
        public string Type { get; set; }

        //[Display(DateTime.Today)]
        [DataType(DataType.Date)]
        public DateTime transactionDate { get; set; }

    }
}
