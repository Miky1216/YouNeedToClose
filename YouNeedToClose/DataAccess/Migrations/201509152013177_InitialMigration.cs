namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TermModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ProjectedGoal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectedGoalModels", t => t.ProjectedGoal_Id)
                .Index(t => t.ProjectedGoal_Id);
            
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
                        TermModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TermModels", t => t.TermModel_Id)
                .Index(t => t.TermModel_Id);
            
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
            DropForeignKey("dbo.CustomerModels", "TermModel_Id", "dbo.TermModels");
            DropForeignKey("dbo.CategoryModels", "TermModel_Id", "dbo.TermModels");
            DropIndex("dbo.CustomerModels", new[] { "TermModel_Id" });
            DropIndex("dbo.CategoryModels", new[] { "TermModel_Id" });
            DropIndex("dbo.TermModels", new[] { "ProjectedGoal_Id" });
            DropTable("dbo.ProjectedGoalModels");
            DropTable("dbo.CustomerModels");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.TermModels");
        }
    }
}
