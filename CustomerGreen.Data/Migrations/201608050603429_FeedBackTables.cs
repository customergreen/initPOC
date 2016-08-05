namespace CustomerGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedBackTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckoutPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgId = c.Int(nullable: false),
                        CheckoutLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedbackCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgId = c.Int(nullable: false),
                        CategoryKey = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgId = c.Int(nullable: false),
                        CategoryKey = c.String(),
                        FeedbackQuestion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgId = c.Int(nullable: false),
                        FeedbackTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Titles");
            DropTable("dbo.Questions");
            DropTable("dbo.FeedbackCategories");
            DropTable("dbo.CheckoutPoints");
        }
    }
}
