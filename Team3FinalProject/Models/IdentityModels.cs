using System.Data.Entity;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Team3FinalProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AppUser : IdentityUser
    {


        //For instance
        public string FName { get; set; }
        public string LName { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public States State { get; set; }
        public String Zip { get; set; }
        public String Birthday { get; set; }
        public String MiddleInitial { get; set; }






        public virtual List<CheckingAccount> CheckingAccounts { get; set; }
        public virtual List<SavingAccount> SavingAccounts { get; set; }
        public virtual List<IRAAccount> IRAAccounts { get; set; }
        public virtual List<StockPortfolio> StockPortfolios { get; set; }


        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //Remember, Identity adds a db set for users, so you shouldn't add that one - you will get an error
        //public DbSet<Book> Books { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<SavingAccount> SavingAcocunts { get; set; }
        public DbSet<IRAAccount> IRAAccounts { get; set; }
        public DbSet<StockPortfolio> StockPortfolios { get; set; }


        public AppDbContext()
            : base("MyDBConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<AppRole> AppRoles { get; set; }


    }
}