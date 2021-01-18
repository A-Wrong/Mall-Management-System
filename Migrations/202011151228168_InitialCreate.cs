namespace Shopping_Mall_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Userid = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Userid);
            
            CreateTable(
                "dbo.BussinessProfiles",
                c => new
                    {
                        BussinessProfileId = c.String(nullable: false, maxLength: 128),
                        ShopName = c.String(),
                        BusinessCategory = c.String(),
                        TotalEmployees = c.Int(nullable: false),
                        Workinghours = c.Int(nullable: false),
                        Holiday = c.String(),
                        LicenseNumber = c.String(),
                        LicenseExpiryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BussinessProfileId)
                .ForeignKey("dbo.User_Details", t => t.BussinessProfileId)
                .Index(t => t.BussinessProfileId);
            
            CreateTable(
                "dbo.User_Details",
                c => new
                    {
                        Userid = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Userid);
            
            CreateTable(
                "dbo.RentOrLeaseRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        StoreNumber = c.String(maxLength: 128),
                        StoreLocation = c.String(),
                        Type = c.String(),
                        StoreOwnerName = c.String(),
                        ContactNumber = c.String(),
                        BusinessCategory = c.String(),
                        Tenure = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Store", t => t.StoreNumber)
                .Index(t => t.StoreNumber);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Storenumber = c.String(nullable: false, maxLength: 128),
                        Storesize = c.String(nullable: false),
                        Storelocation = c.String(nullable: false),
                        StoreArea = c.Int(nullable: false),
                        OccupencyStatus = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        StoreName = c.String(),
                        BusinessCategory = c.String(),
                        Tenure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Storenumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentOrLeaseRequests", "StoreNumber", "dbo.Store");
            DropForeignKey("dbo.BussinessProfiles", "BussinessProfileId", "dbo.User_Details");
            DropIndex("dbo.RentOrLeaseRequests", new[] { "StoreNumber" });
            DropIndex("dbo.BussinessProfiles", new[] { "BussinessProfileId" });
            DropTable("dbo.Store");
            DropTable("dbo.RentOrLeaseRequests");
            DropTable("dbo.User_Details");
            DropTable("dbo.BussinessProfiles");
            DropTable("dbo.Admin");
        }
    }
}
