namespace Sanctuary.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.TblBookings", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TblBookings", "DiscountAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TblUsers", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.TblUsers", "LoyaltyTier", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblUserAmount", new[] { "User_Id", "User_Email" }, "dbo.TblUsers");
            DropIndex("dbo.TblUserAmount", new[] { "User_Id", "User_Email" });
            DropColumn("dbo.TblUsers", "LoyaltyTier");
            DropColumn("dbo.TblUsers", "IsAdmin");
            DropColumn("dbo.TblBookings", "DiscountAmount");
            DropColumn("dbo.TblBookings", "Amount");
            DropTable("dbo.TblUserAmount");
        }
    }
}
