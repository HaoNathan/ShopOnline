namespace ShopOnline.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImagePathLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "ImagePath", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "ImagePath", c => c.String(maxLength: 50));
        }
    }
}
