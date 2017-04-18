using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3FinalProject.Models
{
    public class CheckingAccount
    {

        public Int32 CheckingAccountID { get; set; }
        public String AccountNumber { get; set; }
        public Decimal AccountBalance { get; set; }
        //TODO: stock portfolio later bitches.

        public virtual AppUser AppUser { get; set; }

    }
}