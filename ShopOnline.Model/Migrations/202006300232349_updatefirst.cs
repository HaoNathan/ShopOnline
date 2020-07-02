namespace ShopOnline.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AdminName = c.String(nullable: false, maxLength: 30),
                        AdminPassword = c.String(nullable: false, maxLength: 30),
                        ImagePath = c.String(nullable: false, maxLength: 32),
                        RolesId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RolesId)
                .Index(t => t.RolesId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RolesName = c.String(nullable: false, maxLength: 30),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Business",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, storeType: "money"),
                        ProductId = c.Guid(nullable: false),
                        PayTypeId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PayType", t => t.PayTypeId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.PayTypeId);
            
            CreateTable(
                "dbo.PayType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PayTypeName = c.String(nullable: false, maxLength: 30),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 30),
                        ProductPrice = c.Decimal(nullable: false, storeType: "money"),
                        ProductCost = c.Decimal(nullable: false, storeType: "money"),
                        ProductImagePath = c.String(nullable: false, unicode: false, storeType: "text"),
                        ProductNumber = c.Int(nullable: false),
                        ProductDescription = c.String(unicode: false, storeType: "text"),
                        ColorId = c.Guid(nullable: false),
                        SizeId = c.Guid(nullable: false),
                        FirstProductCategoryId = c.Guid(nullable: false),
                        SecondProductCategoryId = c.Guid(nullable: false),
                        ThirdProductCategoryId = c.Guid(nullable: false),
                        GS1Id = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Color", t => t.ColorId)
                .ForeignKey("dbo.FirstProductCategory", t => t.FirstProductCategoryId)
                .ForeignKey("dbo.SecondProductCategory", t => t.SecondProductCategoryId)
                .ForeignKey("dbo.Size", t => t.SizeId)
                .ForeignKey("dbo.ThirdProductCategory", t => t.ThirdProductCategoryId)
                .Index(t => t.ColorId)
                .Index(t => t.SizeId)
                .Index(t => t.FirstProductCategoryId)
                .Index(t => t.SecondProductCategoryId)
                .Index(t => t.ThirdProductCategoryId);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ColorName = c.String(nullable: false, maxLength: 20),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FirstProductCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstProductCategoryName = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecondProductCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SecondProductCategoryName = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SizeName = c.String(nullable: false, maxLength: 20),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThirdProductCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ThirdProductCategoryName = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Collect",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 30),
                        UserPassword = c.String(nullable: false, maxLength: 30),
                        Email = c.String(maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 11),
                        ImagePath = c.String(maxLength: 50),
                        IsMember = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        PayState = c.Int(nullable: false),
                        UserDistributionId = c.Guid(nullable: false),
                        DeliverySate = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.UserDistribution", t => t.UserDistributionId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId)
                .Index(t => t.UserDistributionId);
            
            CreateTable(
                "dbo.UserDistribution",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ConsigneeAddress = c.String(nullable: false, maxLength: 40),
                        ConsigneePhone = c.String(nullable: false, maxLength: 11),
                        ConsigneeName = c.String(nullable: false, maxLength: 10),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductComment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 200),
                        UserId = c.Guid(nullable: false),
                        Praise = c.Int(nullable: false),
                        Oppose = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ShoppingCart",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ColorId = c.Guid(nullable: false),
                        SizeId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Color", t => t.ColorId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Size", t => t.SizeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId)
                .Index(t => t.ColorId)
                .Index(t => t.SizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCart", "UserId", "dbo.User");
            DropForeignKey("dbo.ShoppingCart", "SizeId", "dbo.Size");
            DropForeignKey("dbo.ShoppingCart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ShoppingCart", "ColorId", "dbo.Color");
            DropForeignKey("dbo.ProductComment", "UserId", "dbo.User");
            DropForeignKey("dbo.ProductComment", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderInfo", "UserDistributionId", "dbo.UserDistribution");
            DropForeignKey("dbo.UserDistribution", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderInfo", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderInfo", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Collect", "UserId", "dbo.User");
            DropForeignKey("dbo.Collect", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Business", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ThirdProductCategoryId", "dbo.ThirdProductCategory");
            DropForeignKey("dbo.Product", "SizeId", "dbo.Size");
            DropForeignKey("dbo.Product", "SecondProductCategoryId", "dbo.SecondProductCategory");
            DropForeignKey("dbo.Product", "FirstProductCategoryId", "dbo.FirstProductCategory");
            DropForeignKey("dbo.Product", "ColorId", "dbo.Color");
            DropForeignKey("dbo.Business", "PayTypeId", "dbo.PayType");
            DropForeignKey("dbo.Admin", "RolesId", "dbo.Roles");
            DropIndex("dbo.ShoppingCart", new[] { "SizeId" });
            DropIndex("dbo.ShoppingCart", new[] { "ColorId" });
            DropIndex("dbo.ShoppingCart", new[] { "UserId" });
            DropIndex("dbo.ShoppingCart", new[] { "ProductId" });
            DropIndex("dbo.ProductComment", new[] { "UserId" });
            DropIndex("dbo.ProductComment", new[] { "ProductId" });
            DropIndex("dbo.UserDistribution", new[] { "UserId" });
            DropIndex("dbo.OrderInfo", new[] { "UserDistributionId" });
            DropIndex("dbo.OrderInfo", new[] { "UserId" });
            DropIndex("dbo.OrderInfo", new[] { "ProductId" });
            DropIndex("dbo.Collect", new[] { "ProductId" });
            DropIndex("dbo.Collect", new[] { "UserId" });
            DropIndex("dbo.Product", new[] { "ThirdProductCategoryId" });
            DropIndex("dbo.Product", new[] { "SecondProductCategoryId" });
            DropIndex("dbo.Product", new[] { "FirstProductCategoryId" });
            DropIndex("dbo.Product", new[] { "SizeId" });
            DropIndex("dbo.Product", new[] { "ColorId" });
            DropIndex("dbo.Business", new[] { "PayTypeId" });
            DropIndex("dbo.Business", new[] { "ProductId" });
            DropIndex("dbo.Admin", new[] { "RolesId" });
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.ProductComment");
            DropTable("dbo.UserDistribution");
            DropTable("dbo.OrderInfo");
            DropTable("dbo.User");
            DropTable("dbo.Collect");
            DropTable("dbo.ThirdProductCategory");
            DropTable("dbo.Size");
            DropTable("dbo.SecondProductCategory");
            DropTable("dbo.FirstProductCategory");
            DropTable("dbo.Color");
            DropTable("dbo.Product");
            DropTable("dbo.PayType");
            DropTable("dbo.Business");
            DropTable("dbo.Roles");
            DropTable("dbo.Admin");
        }
    }
}
