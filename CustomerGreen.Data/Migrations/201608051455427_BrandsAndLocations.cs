namespace CustomerGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrandsAndLocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandLocations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BrandId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Mobile = c.String(),
                        ContactEmail = c.String(maxLength: 50),
                        StrategicEmail = c.String(maxLength: 50),
                        TacticalEmail = c.String(maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Street1 = c.String(nullable: false, maxLength: 100),
                        Street2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 100),
                        Zip = c.String(nullable: false, maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrgId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Mobile = c.String(),
                        ContactEmail = c.String(maxLength: 50),
                        StrategicEmail = c.String(maxLength: 50),
                        TacticalEmail = c.String(maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Street1 = c.String(nullable: false, maxLength: 100),
                        Street2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 100),
                        Zip = c.String(nullable: false, maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)                
                .Index(t => t.OrgId);
           
            AddForeignKey("dbo.Brands","OrgId","dbo.Organizations","Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Brands", "OrgId", "dbo.Organizations");
            DropForeignKey("dbo.BrandLocations", "BrandId", "dbo.Brands");
            DropIndex("dbo.Brands", new[] { "OrgId" });
            DropIndex("dbo.BrandLocations", new[] { "BrandId" });
            DropTable("dbo.Brands");
            DropTable("dbo.BrandLocations");
        }
    }
}
