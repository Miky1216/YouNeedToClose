namespace YouNeedToClose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "DetailsOfCustomer_Id", c => c.Int());
            AddColumn("dbo.TermModels", "DetailsCustomer_Id", c => c.Int());
            CreateIndex("dbo.CustomerModels", "DetailsOfCustomer_Id");
            CreateIndex("dbo.TermModels", "DetailsCustomer_Id");
            AddForeignKey("dbo.CustomerModels", "DetailsOfCustomer_Id", "dbo.DetailsCustomerModels", "Id");
            AddForeignKey("dbo.TermModels", "DetailsCustomer_Id", "dbo.DetailsCustomerModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermModels", "DetailsCustomer_Id", "dbo.DetailsCustomerModels");
            DropForeignKey("dbo.CustomerModels", "DetailsOfCustomer_Id", "dbo.DetailsCustomerModels");
            DropIndex("dbo.TermModels", new[] { "DetailsCustomer_Id" });
            DropIndex("dbo.CustomerModels", new[] { "DetailsOfCustomer_Id" });
            DropColumn("dbo.TermModels", "DetailsCustomer_Id");
            DropColumn("dbo.CustomerModels", "DetailsOfCustomer_Id");
        }
    }
}
