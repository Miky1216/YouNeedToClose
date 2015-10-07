namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigrationDetailsCustomerAdded : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TermModels", "DetailsCustomer_Id", c => c.Int());
            CreateIndex("dbo.TermModels", "DetailsCustomer_Id");
            AddForeignKey("dbo.TermModels", "DetailsCustomer_Id", "dbo.DetailsCustomerModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermModels", "DetailsCustomer_Id", "dbo.DetailsCustomerModels");
            DropIndex("dbo.TermModels", new[] { "DetailsCustomer_Id" });
            DropColumn("dbo.TermModels", "DetailsCustomer_Id");
            DropTable("dbo.DetailsCustomerModels");
        }
    }
}
