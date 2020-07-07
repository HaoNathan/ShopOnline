namespace ShopOnline.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderInfo", "UserDistributionId", "dbo.UserDistribution");
            DropIndex("dbo.OrderInfo", new[] { "UserDistributionId" });
            AlterColumn("dbo.User", "UserPassword", c => c.String(nullable: false, maxLength: 35));
            DropColumn("dbo.OrderInfo", "UserDistributionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderInfo", "UserDistributionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.User", "UserPassword", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.OrderInfo", "UserDistributionId");
            AddForeignKey("dbo.OrderInfo", "UserDistributionId", "dbo.UserDistribution", "Id");
        }
    }
}
