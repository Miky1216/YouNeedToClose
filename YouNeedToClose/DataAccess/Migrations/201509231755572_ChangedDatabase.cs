namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "DetailsOfCustomer_Id", c => c.Int());
            CreateIndex("dbo.CustomerModels", "DetailsOfCustomer_Id");
            AddForeignKey("dbo.CustomerModels", "DetailsOfCustomer_Id", "dbo.DetailsCustomerModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerModels", "DetailsOfCustomer_Id", "dbo.DetailsCustomerModels");
            DropIndex("dbo.CustomerModels", new[] { "DetailsOfCustomer_Id" });
            DropColumn("dbo.CustomerModels", "DetailsOfCustomer_Id");
        }
    }
}
