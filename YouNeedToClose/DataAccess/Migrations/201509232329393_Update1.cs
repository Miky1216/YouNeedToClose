namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CustomerModels", new[] { "DetailsOfCustomer_Id" });
            RenameColumn(table: "dbo.DetailsCustomerModels", name: "DetailsOfCustomer_Id", newName: "CustomerModel_Id");
            CreateIndex("dbo.DetailsCustomerModels", "CustomerModel_Id");
            DropColumn("dbo.CustomerModels", "DetailsOfCustomer_Id");
        }
        
        public override void Down()
        {
            /*AddColumn("dbo.CustomerModels", "DetailsOfCustomer_Id", c => c.Int());
            DropIndex("dbo.DetailsCustomerModels", new[] { "CustomerModel_Id" });
            RenameColumn(table: "dbo.DetailsCustomerModels", name: "CustomerModel_Id", newName: "DetailsOfCustomer_Id");
            CreateIndex("dbo.CustomerModels", "DetailsOfCustomer_Id");*/
        }
    }
}
