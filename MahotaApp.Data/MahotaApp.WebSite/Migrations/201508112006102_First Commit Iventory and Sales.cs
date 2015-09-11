namespace MahotaApp.WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstCommitIventoryandSales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_ID = c.Guid(nullable: false, identity: true),
                        customer_Details = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.customer_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        order_ID = c.Guid(nullable: false, identity: true),
                        customer_ID = c.Guid(nullable: false),
                        date_of_Order = c.DateTime(nullable: false),
                        order_Details = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.order_ID)
                .ForeignKey("dbo.Customers", t => t.customer_ID, cascadeDelete: true)
                .Index(t => t.customer_ID);
            
            CreateTable(
                "dbo.Orders_Items",
                c => new
                    {
                        order_Item_ID = c.Guid(nullable: false, identity: true),
                        order_ID = c.Guid(nullable: false),
                        product_ID = c.Guid(nullable: false),
                        product_Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.order_Item_ID)
                .ForeignKey("dbo.Orders", t => t.order_ID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.product_ID, cascadeDelete: true)
                .Index(t => t.order_ID)
                .Index(t => t.product_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        product_ID = c.Guid(nullable: false, identity: true),
                        product_Type_Code = c.String(maxLength: 50),
                        product_Name = c.String(maxLength: 100),
                        unit_Price = c.Double(nullable: false),
                        product_Description = c.String(maxLength: 250),
                        reorder_Level = c.String(maxLength: 50),
                        redorder_Quantity = c.Double(nullable: false),
                        other_Details = c.String(),
                    })
                .PrimaryKey(t => t.product_ID)
                .ForeignKey("dbo.Product_Types", t => t.product_Type_Code)
                .Index(t => t.product_Type_Code);
            
            CreateTable(
                "dbo.Daily_Iventory_Levels",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        date_of_Iventory = c.DateTime(nullable: false),
                        product_ID = c.Guid(nullable: false),
                        level = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.product_ID, cascadeDelete: true)
                .Index(t => t.product_ID);
            
            CreateTable(
                "dbo.Product_Types",
                c => new
                    {
                        product_Type_Code = c.String(nullable: false, maxLength: 50),
                        parent_Product_Type_Code = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.product_Type_Code)
                .ForeignKey("dbo.Product_Types", t => t.parent_Product_Type_Code)
                .Index(t => t.parent_Product_Type_Code);
            
            AlterColumn("dbo.Equipment_Iventory", "asset_Number", c => c.String(maxLength: 50));
            AlterColumn("dbo.Equipment_Iventory", "serial_Number", c => c.String(maxLength: 50));
            AlterColumn("dbo.Equipment_Iventory", "tooling_Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Equipment_Iventory", "embossed_Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Equipment_Iventory", "in_Use_Where", c => c.String(maxLength: 50));
            AlterColumn("dbo.Equipment_Iventory", "other_Detais", c => c.String(maxLength: 250));
            AlterColumn("dbo.Locations", "location_Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Ref_Tooling_Types", "tooling_Type_Description", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "product_Type_Code", "dbo.Product_Types");
            DropForeignKey("dbo.Product_Types", "parent_Product_Type_Code", "dbo.Product_Types");
            DropForeignKey("dbo.Orders_Items", "product_ID", "dbo.Products");
            DropForeignKey("dbo.Daily_Iventory_Levels", "product_ID", "dbo.Products");
            DropForeignKey("dbo.Orders_Items", "order_ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "customer_ID", "dbo.Customers");
            DropIndex("dbo.Product_Types", new[] { "parent_Product_Type_Code" });
            DropIndex("dbo.Daily_Iventory_Levels", new[] { "product_ID" });
            DropIndex("dbo.Products", new[] { "product_Type_Code" });
            DropIndex("dbo.Orders_Items", new[] { "product_ID" });
            DropIndex("dbo.Orders_Items", new[] { "order_ID" });
            DropIndex("dbo.Orders", new[] { "customer_ID" });
            AlterColumn("dbo.Ref_Tooling_Types", "tooling_Type_Description", c => c.String());
            AlterColumn("dbo.Locations", "location_Name", c => c.String());
            AlterColumn("dbo.Equipment_Iventory", "other_Detais", c => c.String());
            AlterColumn("dbo.Equipment_Iventory", "in_Use_Where", c => c.String());
            AlterColumn("dbo.Equipment_Iventory", "embossed_Name", c => c.String());
            AlterColumn("dbo.Equipment_Iventory", "tooling_Name", c => c.String());
            AlterColumn("dbo.Equipment_Iventory", "serial_Number", c => c.String());
            AlterColumn("dbo.Equipment_Iventory", "asset_Number", c => c.String());
            DropTable("dbo.Product_Types");
            DropTable("dbo.Daily_Iventory_Levels");
            DropTable("dbo.Products");
            DropTable("dbo.Orders_Items");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
