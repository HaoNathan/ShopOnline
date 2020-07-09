namespace ShopOnline.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderInfo", "ProductId", "dbo.Product");
            DropIndex("dbo.OrderInfo", new[] { "ProductId" });
            DropColumn("dbo.OrderInfo", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderInfo", "ProductId", c => c.Guid(nullable: false));
            CreateIndex("dbo.OrderInfo", "ProductId");
            AddForeignKey("dbo.OrderInfo", "ProductId", "dbo.Product", "Id");
        }
    }
}
