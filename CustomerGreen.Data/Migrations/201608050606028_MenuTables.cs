namespace CustomerGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuTables : DbMigration
    {
        public override void Up()
        {
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
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.ApplicationRole_Id)
                .Index(t => t.Menu_Id);
            
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

            //Insert Default Menu Items

            Sql("INSERT INTO [Menus] ([Name],[Url],[DisplayName]) VALUES ( 'Dashboard','url','Dashboard' ) ");
            Sql("INSERT INTO [Menus] ([Name],[Url],[DisplayName]) VALUES ( 'Questions','url','Setup Questions' ) ");
            Sql("INSERT INTO [Menus] ([Name],[Url],[DisplayName]) VALUES ( 'Feedback','url','Setup Feedback' ) ");
            Sql("INSERT INTO [Menus] ([Name],[Url],[DisplayName]) VALUES ( 'Alerts','url','Setup Alerts' ) ");
            
            
        }
        
        public override void Down()
        {            
            DropForeignKey("dbo.MenuAccess", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.MenuAccess", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.MenuAccess", new[] { "Menu_Id" });
            DropIndex("dbo.MenuAccess", new[] { "ApplicationRole_Id" });
            Sql("DELETE from dbo.Menus");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuAccess");
        }
    }
}