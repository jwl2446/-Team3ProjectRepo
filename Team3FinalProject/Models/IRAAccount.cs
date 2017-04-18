﻿using System;
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
        //TODO: stock portfolio later bitches.

        public virtual AppUser AppUser { get; set; }
    }
}