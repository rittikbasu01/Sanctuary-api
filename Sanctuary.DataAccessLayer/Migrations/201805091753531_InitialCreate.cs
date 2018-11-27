namespace Sanctuary.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAssets",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        RoomType = c.String(nullable: false),
                        NoOfRooms = c.Int(nullable: false),
                        RoomPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.TblLocations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.TblLocations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationCountry = c.String(nullable: false),
                        LocationCity = c.String(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.TblBookings",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        User_Email = c.String(maxLength: 128),
                        Asset_Id = c.Int(nullable: false),
                        BookingId = c.Int(nullable: false, identity: true),
                        BookingFromDate = c.DateTime(nullable: false),
                        BookingToDate = c.DateTime(nullable: false),
                        NoOfRooms = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.TblAssets", t => t.Asset_Id, cascadeDelete: true)
                .ForeignKey("dbo.TblUsers", t => new { t.User_Id, t.User_Email })
                .Index(t => new { t.User_Id, t.User_Email })
                .Index(t => t.Asset_Id);
            
            CreateTable(
                "dbo.TblUsers",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        SecurityQuestion = c.Int(nullable: false),
                        SecurityQuestionAnswer = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        LoyaltyTier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.Email })
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.TblUserAmount",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        User_Email = c.String(maxLength: 128),
                        UserAmountID = c.Int(nullable: false, identity: true),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UserAmountID)
                .ForeignKey("dbo.TblUsers", t => new { t.User_Id, t.User_Email })
                .Index(t => new { t.User_Id, t.User_Email });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblUserAmount", new[] { "User_Id", "User_Email" }, "dbo.TblUsers");
            DropForeignKey("dbo.TblBookings", new[] { "User_Id", "User_Email" }, "dbo.TblUsers");
            DropForeignKey("dbo.TblBookings", "Asset_Id", "dbo.TblAssets");
            DropForeignKey("dbo.TblAssets", "LocationId", "dbo.TblLocations");
            DropIndex("dbo.TblUserAmount", new[] { "User_Id", "User_Email" });
            DropIndex("dbo.TblUsers", new[] { "Email" });
            DropIndex("dbo.TblBookings", new[] { "Asset_Id" });
            DropIndex("dbo.TblBookings", new[] { "User_Id", "User_Email" });
            DropIndex("dbo.TblAssets", new[] { "LocationId" });
            DropTable("dbo.TblUserAmount");
            DropTable("dbo.TblUsers");
            DropTable("dbo.TblBookings");
            DropTable("dbo.TblLocations");
            DropTable("dbo.TblAssets");
        }
    }
}
