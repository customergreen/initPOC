namespace CustomerGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                .ForeignKey("dbo.Organizations", t => t.OrgId, cascadeDelete: true)
                .Index(t => t.OrgId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrgKey = c.String(maxLength: 50),
                        CompanyName = c.String(nullable: false, maxLength: 500),
                        Phone = c.String(nullable: false),
                        Mobile = c.String(),
                        ContactEmail = c.String(maxLength: 50),
                        StrategicEmail = c.String(maxLength: 50),
                        TacticalEmail = c.String(maxLength: 50),
                        About = c.String(maxLength: 250),
                        Website = c.String(maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Street1 = c.String(nullable: false, maxLength: 100),
                        Street2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 100),
                        Zip = c.String(nullable: false, maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        Logo = c.Binary(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        BusinessSubType_Id = c.Long(),
                        BusinessType_Id = c.Long(),
                        LicenseType_Id = c.Long(),
                        OrganizationDetails_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessSubTypes", t => t.BusinessSubType_Id)
                .ForeignKey("dbo.BusinessTypes", t => t.BusinessType_Id)
                .ForeignKey("dbo.LicenseTypes", t => t.LicenseType_Id)
                .ForeignKey("dbo.OrganizationDetails", t => t.OrganizationDetails_Id)
                .Index(t => t.OrgKey, unique: true)
                .Index(t => t.CompanyName, unique: true)
                .Index(t => t.BusinessSubType_Id)
                .Index(t => t.BusinessType_Id)
                .Index(t => t.LicenseType_Id)
                .Index(t => t.OrganizationDetails_Id);
            
            CreateTable(
                "dbo.BusinessSubTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SubType = c.String(),
                        BusinessType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessTypes", t => t.BusinessType_Id)
                .Index(t => t.BusinessType_Id);
            
            CreateTable(
                "dbo.BusinessTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Business = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LicenseTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        License = c.String(),
                        Cost = c.Double(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizationDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrgId = c.Long(nullable: false),
                        RenewDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        PaymentReceived = c.Boolean(),
                        PaymentDue = c.Double(nullable: false),
                        LocationCount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckoutPoints",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrgId = c.Long(nullable: false),
                        CheckoutLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 250),
                        Telephone = c.String(maxLength: 150),
                        MobilePhone = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 250),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(),
                        Activated = c.Boolean(nullable: false),
                        OrgId = c.Long(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedbackCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrgId = c.Long(nullable: false),
                        CategoryKey = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuAccess",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Read = c.Boolean(nullable: false),
                        Update = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        ApplicationRole_Id = c.String(maxLength: 128),
                        Menu_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.ApplicationRole_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        OrgId = c.Long(),
                        DisplayName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Usage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrgId = c.Long(nullable: false),
                        CategoryKey = c.String(),
                        FeedbackQuestion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Revenues",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Annual = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrgId = c.Int(nullable: false),
                        FeedbackTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MenuAccess", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.MenuAccess", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.Contacts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Organizations", "OrganizationDetails_Id", "dbo.OrganizationDetails");
            DropForeignKey("dbo.Organizations", "LicenseType_Id", "dbo.LicenseTypes");
            DropForeignKey("dbo.Organizations", "BusinessType_Id", "dbo.BusinessTypes");
            DropForeignKey("dbo.Organizations", "BusinessSubType_Id", "dbo.BusinessSubTypes");
            DropForeignKey("dbo.BusinessSubTypes", "BusinessType_Id", "dbo.BusinessTypes");
            DropForeignKey("dbo.Brands", "OrgId", "dbo.Organizations");
            DropForeignKey("dbo.BrandLocations", "BrandId", "dbo.Brands");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.MenuAccess", new[] { "Menu_Id" });
            DropIndex("dbo.MenuAccess", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Contacts", new[] { "ApplicationUserId" });
            DropIndex("dbo.BusinessSubTypes", new[] { "BusinessType_Id" });
            DropIndex("dbo.Organizations", new[] { "OrganizationDetails_Id" });
            DropIndex("dbo.Organizations", new[] { "LicenseType_Id" });
            DropIndex("dbo.Organizations", new[] { "BusinessType_Id" });
            DropIndex("dbo.Organizations", new[] { "BusinessSubType_Id" });
            DropIndex("dbo.Organizations", new[] { "CompanyName" });
            DropIndex("dbo.Organizations", new[] { "OrgKey" });
            DropIndex("dbo.Brands", new[] { "OrgId" });
            DropIndex("dbo.BrandLocations", new[] { "BrandId" });
            DropTable("dbo.Titles");
            DropTable("dbo.Revenues");
            DropTable("dbo.Questions");
            DropTable("dbo.Plans");
            DropTable("dbo.Menus");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MenuAccess");
            DropTable("dbo.FeedbackCategories");
            DropTable("dbo.Countries");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Contacts");
            DropTable("dbo.CheckoutPoints");
            DropTable("dbo.OrganizationDetails");
            DropTable("dbo.LicenseTypes");
            DropTable("dbo.BusinessTypes");
            DropTable("dbo.BusinessSubTypes");
            DropTable("dbo.Organizations");
            DropTable("dbo.Brands");
            DropTable("dbo.BrandLocations");
        }
    }
}
