namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailsCustomerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        CustomerMotivations = c.String(),
                        CustomerModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerModels", t => t.CustomerModel_Id)
                .Index(t => t.CustomerModel_Id);
            
            AddColumn("dbo.TermModels", "DetailsCustomer_Id", c => c.Int());
            CreateIndex("dbo.TermModels", "DetailsCustomer_Id");
            AddForeignKey("dbo.TermModels", "DetailsCustomer_Id", "dbo.DetailsCustomerModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermModels", "DetailsCustomer_Id", "dbo.DetailsCustomerModels");
            DropForeignKey("dbo.DetailsCustomerModels", "CustomerModel_Id", "dbo.CustomerModels");
            DropIndex("dbo.TermModels", new[] { "DetailsCustomer_Id" });
            DropIndex("dbo.DetailsCustomerModels", new[] { "CustomerModel_Id" });
            DropColumn("dbo.TermModels", "DetailsCustomer_Id");
            DropTable("dbo.DetailsCustomerModels");
        }
    }
}
