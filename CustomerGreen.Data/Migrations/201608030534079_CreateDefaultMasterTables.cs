using Microsoft.AspNet.Identity.Owin;

namespace CustomerGreen.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateDefaultMasterTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefaultCheckoutPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckoutPoint = c.String(),                        
                    })
                .PrimaryKey(t => t.Id);
            //Insert Default Data
            Sql("INSERT INTO [DefaultCheckoutPoints] ([CheckoutPoint]) VALUES ( 'Online Payment' ) ");
            Sql("INSERT INTO [DefaultCheckoutPoints] ([CheckoutPoint]) VALUES ( 'Wire Transfer' ) ");
            Sql("INSERT INTO [DefaultCheckoutPoints] ([CheckoutPoint]) VALUES ( 'Store POS' ) ");
            Sql("INSERT INTO [DefaultCheckoutPoints] ([CheckoutPoint]) VALUES ( 'Credit Card' ) ");

            CreateTable(
                "dbo.DefaultFeedbackCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryKey= c.String(nullable:false),
                        Category = c.String(nullable:false),
                    })
                .PrimaryKey(t => t.Id);
            //Insert Default Data
            Sql("INSERT INTO [DefaultFeedbackCategories] ([CategoryKey],[Category]) VALUES ( 'PROD','Product' ) ");
            Sql("INSERT INTO [DefaultFeedbackCategories] ([CategoryKey],[Category]) VALUES ( 'STAF', 'Staff' ) ");
            Sql("INSERT INTO [DefaultFeedbackCategories] ([CategoryKey],[Category]) VALUES ( 'SITE', 'Site' ) ");
            Sql("INSERT INTO [DefaultFeedbackCategories] ([CategoryKey],[Category]) VALUES ( 'STOR', 'Store/Office' ) ");
            Sql("INSERT INTO [DefaultFeedbackCategories] ([CategoryKey],[Category]) VALUES ( 'CHKT', 'Checkout' ) ");

            CreateTable(
                "dbo.DefaultTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable:false)                        
                    })
                .PrimaryKey(t => t.Id);
            //Insert Default Data
            Sql("INSERT INTO [DefaultTitles] ([Title]) VALUES ( 'How Was Your Experience?' ) ");
            Sql("INSERT INTO [DefaultTitles] ([Title]) VALUES ( 'Did We Serve You Well?' ) ");
            Sql("INSERT INTO [DefaultTitles] ([Title]) VALUES ( 'Please Rate Us!!' ) ");
            Sql("INSERT INTO [DefaultTitles] ([Title]) VALUES ( 'Did You Find Everything?' ) ");            

            CreateTable(
                "dbo.DefaultQuestions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CategoryKey = c.String(nullable: false),
                    Question = c.String(nullable:false)                    
                })
                .PrimaryKey(t => t.Id);

            //PRODUCT
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'PROD','Product Pictures') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'PROD','Product Asortment') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'PROD','Product Selection') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'PROD','Product Price') ");

            //STAFF
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'STAF', 'Staff') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'STAF', 'Customer Service') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'STAF', 'Personal Assistance') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'STAF', 'Chat Assistant') ");

            //SITE
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'SITE', 'Layout') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'SITE', 'Usability') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'SITE', 'User Experience') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'SITE', 'Speed') ");

            //STORE
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'STOR', 'In Store Assistance') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'STOR', 'Store Layout') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'STOR', 'Operations') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'STOR', 'Location') ");

            //CHECKOUT
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'CHKT', 'Checkout Experience') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'CHKT', 'Checkout Speed') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'CHKT', 'User Satisfaction') ");
            Sql("INSERT INTO [DefaultQuestions] ([CategoryKey],[Question]) VALUES ( 'CHKT', 'Assistance') ");
        }
        
        public override void Down()
        {
            DropTable("dbo.DefaultQuestions");
            DropTable("dbo.DefaultTitles");
            DropTable("dbo.DefaultCheckoutPoints");
            DropTable("dbo.DefaultFeedbackCategories");                     
        }
    }
}