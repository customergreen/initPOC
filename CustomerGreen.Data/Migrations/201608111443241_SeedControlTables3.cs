namespace CustomerGreen.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SeedControlTables3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.SurveyGoals",
                    c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Goal = c.String(),
                        DefaultValue = c.String(),
                        ValType = c.String()
                    })
                    .PrimaryKey(t => t.Id);
            //Insert Default Data
            Sql("INSERT INTO [SurveyGoals] ([Goal],[DefaultValue],[ValType]) VALUES ( 'Max Negative', '30','Percent' ) ");
            Sql("INSERT INTO [SurveyGoals] ([Goal],[DefaultValue],[ValType]) VALUES ( 'Min Positive','30','Percent' ) ");
            Sql("INSERT INTO [SurveyGoals] ([Goal],[DefaultValue],[ValType]) VALUES ( 'Total Sales','','Amount' ) ");
            Sql("INSERT INTO [SurveyGoals] ([Goal],[DefaultValue],[ValType]) VALUES ( 'Average Sales','','Amount' ) ");
            Sql("INSERT INTO [SurveyGoals] ([Goal],[DefaultValue],[ValType]) VALUES ( 'Gross Profit','','Percent' ) ");
            Sql("INSERT INTO [SurveyGoals] ([Goal],[DefaultValue],[ValType]) VALUES ( 'New Customers','','Count' ) ");
            Sql("INSERT INTO [SurveyGoals] ([Goal],[DefaultValue],[ValType]) VALUES ( 'Customer Retention Rate','','Count' ) ");
        }
        
        public override void Down()
        {
            Sql("DELETE from SurveyGoals");
            DropTable("dbo.SurveyGoals");
        }
    }
}