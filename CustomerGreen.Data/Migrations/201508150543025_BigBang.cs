using System.Transactions.Configuration;

namespace CustomerGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigBang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LicenseTypes",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    License = c.String(nullable: false, maxLength: 256),
                    Cost = c.Double(nullable: false),
                    StartTime = c.DateTime(nullable: false),
                    EndTime = c.DateTime(nullable: false),
                    Active = c.Boolean(nullable: false)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.License, unique: true, name: "LicenseTypeIndex");

            CreateTable(
                "dbo.BusinessType",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Business = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Business, unique: true, name: "BusinessTypeIndex");

            CreateTable(
                "dbo.BusinessSubType",
                c => new
                {
                    Id = c.Long(nullable: false,identity:true),
                    BusinessId = c.Long(nullable: false),
                    BusinessSubType = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessType", t => t.BusinessId, cascadeDelete: true);

            CreateTable(
                "dbo.Organizations",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    OrgKey = c.String(nullable:false, maxLength:100),
                    CompanyName = c.String(nullable:false,maxLength:1000),
                    Phone = c.String(),
                    Mobile = c.String(),
                    BusinessTypeId = c.Long(nullable:true),
                    BusinessSubTypeId = c.Long(nullable:true),
                    LicenseTypeId = c.Long(nullable:false),
                    ContactEmail  = c.String(nullable:false),
                    StrategicEmail = c.String(nullable:false),
                    TacticalEmail = c.String(nullable:false),
                    About = c.String(),
                    Website = c.String(nullable:false),
                    Country = c.String(),
                    Street1 = c.String(),
                    Street2 = c.String(),
                    City = c.String(),
                    State = c.String(),
                    Zip = c.String(),
                    IsActive = c.Boolean(defaultValue:true),
                    Logo = c.Byte(),
                    CreatedDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(maxLength: 256),
                    UpdatedDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicenseTypes", t => t.LicenseTypeId)
                .Index(t => t.OrgKey, unique: true, name: "OrgKeyIndex");

            CreateTable(
                "dbo.OrganizationDetail",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    OrgId = c.Long(nullable:false),
                    RenewDate = c.DateTime(nullable:true),
                    DueDate = c.DateTime(nullable:false),
                    PaymentReceived = c.Boolean(defaultValue:false),
                    PaymentDue = c.Double(),
                    LocationCount = c.Int(),
                    CreatedDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(maxLength: 256),
                    UpdatedDate = c.DateTime(nullable: false),
                    UpdatedBy = c.String(maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrgId);

            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        OrgId = c.Long(),
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        OrgId = c.Long(nullable: false),
                        DisplayName = c.String()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrgId, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex")
                .Index(t => t.OrgId);

            AddColumn("dbo.AspNetUsers", "OrgId", c => c.Long(nullable: false));
            AddColumn("dbo.AspNetRoles", "OrgId", c => c.Long());
            AddColumn("dbo.AspNetRoles", "DisplayName", c => c.String());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Contacts", new[] { "ApplicationUserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Contacts");
            DropTable("dbo.OrganizationDetail");
            DropTable("dbo.Organizations");
            DropTable("dbo.BusinessSubType");
            DropTable("dbo.BusinessType");
            DropTable("dbo.LicenseTypes");
        }
    }
}
