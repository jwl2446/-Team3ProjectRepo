namespace Team3FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CheckingAccounts",
                c => new
                    {
                        CheckingAccountID = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountName = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CheckingAccountID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FName = c.String(),
                        LName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        Zip = c.String(),
                        Birthday = c.String(),
                        MiddleInitial = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IRAAccounts",
                c => new
                    {
                        IRAAccountID = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountName = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IRAAccountID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ToAccount = c.String(),
                        FromAccount = c.String(),
                        Date = c.String(),
                        ConfirmationNumber = c.String(),
                        TransferAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                        TransactionDescription = c.String(),
                        Comments = c.String(),
                        CheckingAccount_CheckingAccountID = c.Int(),
                        IRAAccount_IRAAccountID = c.Int(),
                        SavingAccount_SavingAccountID = c.Int(),
                        StockPortfolio_StockPortfolioID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.CheckingAccounts", t => t.CheckingAccount_CheckingAccountID)
                .ForeignKey("dbo.IRAAccounts", t => t.IRAAccount_IRAAccountID)
                .ForeignKey("dbo.SavingAccounts", t => t.SavingAccount_SavingAccountID)
                .ForeignKey("dbo.StockPortfolios", t => t.StockPortfolio_StockPortfolioID)
                .Index(t => t.CheckingAccount_CheckingAccountID)
                .Index(t => t.IRAAccount_IRAAccountID)
                .Index(t => t.SavingAccount_SavingAccountID)
                .Index(t => t.StockPortfolio_StockPortfolioID);
            
            CreateTable(
                "dbo.SavingAccounts",
                c => new
                    {
                        SavingAccountID = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountName = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SavingAccountID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.StockPortfolios",
                c => new
                    {
                        StockPortfolioID = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountName = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StockPortfolioID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "StockPortfolio_StockPortfolioID", "dbo.StockPortfolios");
            DropForeignKey("dbo.StockPortfolios", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "SavingAccount_SavingAccountID", "dbo.SavingAccounts");
            DropForeignKey("dbo.SavingAccounts", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "IRAAccount_IRAAccountID", "dbo.IRAAccounts");
            DropForeignKey("dbo.Transactions", "CheckingAccount_CheckingAccountID", "dbo.CheckingAccounts");
            DropForeignKey("dbo.IRAAccounts", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CheckingAccounts", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.StockPortfolios", new[] { "AppUser_Id" });
            DropIndex("dbo.SavingAccounts", new[] { "AppUser_Id" });
            DropIndex("dbo.Transactions", new[] { "StockPortfolio_StockPortfolioID" });
            DropIndex("dbo.Transactions", new[] { "SavingAccount_SavingAccountID" });
            DropIndex("dbo.Transactions", new[] { "IRAAccount_IRAAccountID" });
            DropIndex("dbo.Transactions", new[] { "CheckingAccount_CheckingAccountID" });
            DropIndex("dbo.IRAAccounts", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CheckingAccounts", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.StockPortfolios");
            DropTable("dbo.SavingAccounts");
            DropTable("dbo.Transactions");
            DropTable("dbo.IRAAccounts");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CheckingAccounts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
