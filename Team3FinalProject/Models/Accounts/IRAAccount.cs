using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Team3FinalProject.Models
{
    public class IRAAccount
    {

        public Int32 IRAAccountID { get; set; }
        public String AccountNumber { get; set; }
        public Decimal AccountBalance { get; set; }
        public String AccountName { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}