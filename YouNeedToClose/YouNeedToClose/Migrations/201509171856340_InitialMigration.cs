namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfCategory = c.String(),
                        TermModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TermModels", t => t.TermModel_Id)
                .Index(t => t.TermModel_Id);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfCompany = c.String(),
                        BudgetActualCustomer_Budget = c.Double(nullable: false),
                        BudgetActualCustomer_Actual = c.Double(nullable: false),
                        CategoryModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryModels", t => t.CategoryModel_Id)
                .Index(t => t.CategoryModel_Id);
            
            CreateTable(
                "dbo.TermModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        NextId = c.Int(nullable: false),
                        PrevId = c.Int(nullable: false),
                        ProjectedGoal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectedGoalModels", t => t.ProjectedGoal_Id)
                .Index(t => t.ProjectedGoal_Id);
            
            CreateTable(
                "dbo.ProjectedGoalModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpectedAmountToEarn = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermModels", "ProjectedGoal_Id", "dbo.ProjectedGoalModels");
            DropForeignKey("dbo.CategoryModels", "TermModel_Id", "dbo.TermModels");
            DropForeignKey("dbo.CustomerModels", "CategoryModel_Id", "dbo.CategoryModels");
            DropIndex("dbo.TermModels", new[] { "ProjectedGoal_Id" });
            DropIndex("dbo.CustomerModels", new[] { "CategoryModel_Id" });
            DropIndex("dbo.CategoryModels", new[] { "TermModel_Id" });
            DropTable("dbo.ProjectedGoalModels");
            DropTable("dbo.TermModels");
            DropTable("dbo.CustomerModels");
            DropTable("dbo.CategoryModels");
        }
    }
}
