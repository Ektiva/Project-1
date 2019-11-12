using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EktivaBankNetApp.Models.ViewModel
{
    public class TransactionRange
    {
        public int Id { get; set; }
      
        public int AccountNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime transactionFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime transactionTo { get; set; }
    }
}
