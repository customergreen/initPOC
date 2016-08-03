namespace CustomerGreen.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateMenuRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Url = c.String(nullable: false),
                    DisplayName = c.String(nullable: false)
                })
                .PrimaryKey(t => t.Id);
            //Insert Default Menu Items

            Sql("INSERT INTO [Menus] ([Name],[Url],[DisplayName]) VALUES ( 'Dashboard','url','Dashboard' ) ");
            Sql("INSERT INTO [Menus] ([Name],[Url],[DisplayName]) VALUES ( 'Questions','url','Setup Questions' ) ");
            Sql("INSERT INTO [Menus] ([Name],[Url],[DisplayName]) VALUES ( 'Feedback','url','Setup Feedback' ) ");
            Sql("INSERT INTO [Menus] ([Name],[Url],[DisplayName]) VALUES ( 'Alerts','url','Setup Alerts' ) ");
            
            CreateTable(
                "dbo.MenuAccess",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    MenuId = c.Long(nullable: false),
                    RoleId = c.String(nullable: false, maxLength: 128),
                    Read = c.Boolean(defaultValue: true),
                    Update = c.Boolean(defaultValue: false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true);
        }

        public override void Down()
        {
            DropTable("dbo.MenuAccess");
            DropTable("dbo.Menus");            
        }
    }
}