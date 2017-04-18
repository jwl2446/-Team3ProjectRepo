using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3FinalProject.Models
{

    public enum TransactionType { Withdraw, Deposit, Transfer, BillPay }
    public class Transaction
    {
        

        public Int32 TransactionID { get; set; }
        public String Description { get; set; }
        public String ToAccount { get; set; }
        public String FromAccount { get; set; }
        public String Date { get; set; }
        public String ConfirmationNumber { get; set; }
        public Decimal TransferAmount { get; set; }
        public TransactionType Type { get; set; }
        public String TransactionDescription { get; set; }
        public String Comments { get; set; }

        public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual SavingAccount SavingAccount { get; set; }
        public virtual IRAAccount IRAAccount { get; set; }
        public virtual StockPortfolio StockPortfolio { get; set; }



    }
}