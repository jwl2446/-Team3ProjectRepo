﻿using System;
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
        public String AccountName { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

    }
}