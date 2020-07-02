namespace ShopOnline.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImagePathLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admin", "ImagePath", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admin", "ImagePath", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
