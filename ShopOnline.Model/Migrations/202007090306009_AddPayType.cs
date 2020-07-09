namespace ShopOnline.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPayType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderInfo", "PayType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderInfo", "PayType");
        }
    }
}
