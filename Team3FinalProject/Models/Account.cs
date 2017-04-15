using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3FinalProject.Models
{
    public class Account
    {
        public enum AccountType { Checking, Savings, IRA, StockPortfolio }

        public Int32 AccountID { get; set; }
        public AccountType Type { get; set; }
        public String AccountNumber { get; set; }
        public Decimal AccountBalance { get; set; }
        //TODO: stock portfolio later bitches.

        public virtual User User { get; set; }

    }
}