namespace MahotaApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstCommitDataModelForIventoryofToolingEquipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipment_Iventory",
                c => new
                    {
                        equipment_ID = c.String(nullable: false, maxLength: 128),
                        location_Code = c.String(maxLength: 128),
                        tooling_Type_Code = c.String(maxLength: 128),
                        asset_Number = c.String(),
                        serial_Number = c.String(),
                        tooling_Name = c.String(),
                        qty = c.Double(nullable: false),
                        issue_Date = c.DateTime(),
                        damaged_YN = c.Boolean(nullable: false),
                        embossed_YN = c.Boolean(nullable: false),
                        embossed_Name = c.String(),
                        in_Use_YN = c.Boolean(nullable: false),
                        in_Use_Where = c.String(),
                        expired_Date = c.DateTime(),
                        expired_YN = c.Boolean(nullable: false),
                        other_Detais = c.String(),
                    })
                .PrimaryKey(t => t.equipment_ID)
                .ForeignKey("dbo.Locations", t => t.location_Code)
                .ForeignKey("dbo.Ref_Tooling_Types", t => t.tooling_Type_Code)
                .Index(t => t.location_Code)
                .Index(t => t.tooling_Type_Code);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        location_Code = c.String(nullable: false, maxLength: 128),
                        location_Name = c.String(),
                    })
                .PrimaryKey(t => t.location_Code);
            
            CreateTable(
                "dbo.Ref_Tooling_Types",
                c => new
                    {
                        tooling_Type_Code = c.String(nullable: false, maxLength: 128),
                        tooling_Type_Description = c.String(),
                    })
                .PrimaryKey(t => t.tooling_Type_Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipment_Iventory", "tooling_Type_Code", "dbo.Ref_Tooling_Types");
            DropForeignKey("dbo.Equipment_Iventory", "location_Code", "dbo.Locations");
            DropIndex("dbo.Equipment_Iventory", new[] { "tooling_Type_Code" });
            DropIndex("dbo.Equipment_Iventory", new[] { "location_Code" });
            DropTable("dbo.Ref_Tooling_Types");
            DropTable("dbo.Locations");
            DropTable("dbo.Equipment_Iventory");
        }
    }
}
