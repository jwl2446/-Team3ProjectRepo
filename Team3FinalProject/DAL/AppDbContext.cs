using Team3FinalProject.Models;
using System.Data.Entity;

namespace Team3FinalProject.DAL
{
    public class AppDbContext : DbContext
    {
        //Constructor that invokes the base constructor
        public AppDbContext() : base("MyDBConnection")
        {

        }

        //Create the db set
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }


    }
}