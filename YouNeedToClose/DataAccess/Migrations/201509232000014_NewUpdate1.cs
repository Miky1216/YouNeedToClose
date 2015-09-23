namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TermModels", new[] { "DetailsCustomer_Id" });
            RenameColumn(table: "dbo.DetailsCustomerModels", name: "DetailsCustomer_Id", newName: "TermModel_Id");
            CreateIndex("dbo.DetailsCustomerModels", "TermModel_Id");
            DropColumn("dbo.TermModels", "DetailsCustomer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TermModels", "DetailsCustomer_Id", c => c.Int());
            DropIndex("dbo.DetailsCustomerModels", new[] { "TermModel_Id" });
            RenameColumn(table: "dbo.DetailsCustomerModels", name: "TermModel_Id", newName: "DetailsCustomer_Id");
            CreateIndex("dbo.TermModels", "DetailsCustomer_Id");
        }
    }
}
