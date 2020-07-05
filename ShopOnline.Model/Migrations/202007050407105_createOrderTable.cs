namespace ShopOnline.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Quantity = c.String(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderInfo", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.OrderInfo", "Phone", c => c.String(maxLength: 11));
            AddColumn("dbo.OrderInfo", "AcceptName", c => c.String());
            AddColumn("dbo.OrderInfo", "Address", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Orders", "OrderId", "dbo.OrderInfo");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "OrderId" });
            DropColumn("dbo.OrderInfo", "Address");
            DropColumn("dbo.OrderInfo", "AcceptName");
            DropColumn("dbo.OrderInfo", "Phone");
            DropTable("dbo.Orders");
        }
    }
}
