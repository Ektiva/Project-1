using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EktivaBankNetApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string RegistrationId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int NumberOfAccount { get; set; }

        public virtual IList<Account> Accounts { get; set; }


    }
}
