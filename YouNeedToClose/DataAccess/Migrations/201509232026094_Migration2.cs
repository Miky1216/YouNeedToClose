namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
           /* CreateTable(
                "dbo.DetailsCustomerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        CustomerMotivations = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CustomerModels", "DetailsOfCustomer_Id", c => c.Int());
            AddColumn("dbo.TermModels", "DetailsCustomer_Id", c => c.Int());
            CreateIndex("dbo.CustomerModels", "DetailsOfCustomer_Id");
            CreateIndex("dbo.TermModels", "DetailsCustomer_Id");
            AddForeignKey("dbo.CustomerModels", "DetailsOfCustomer_Id", "dbo.DetailsCustomerModels", "Id");
            AddForeignKey("dbo.TermModels", "DetailsCustomer_Id", "dbo.DetailsCustomerModels", "Id");*/
        }
        
        public override void Down()
        {
            /*DropForeignKey("dbo.TermModels", "DetailsCustomer_Id", "dbo.DetailsCustomerModels");
            DropForeignKey("dbo.CustomerModels", "DetailsOfCustomer_Id", "dbo.DetailsCustomerModels");
            DropIndex("dbo.TermModels", new[] { "DetailsCustomer_Id" });
            DropIndex("dbo.CustomerModels", new[] { "DetailsOfCustomer_Id" });
            DropColumn("dbo.TermModels", "DetailsCustomer_Id");
            DropColumn("dbo.CustomerModels", "DetailsOfCustomer_Id");
            DropTable("dbo.DetailsCustomerModels");*/
        }
    }
}
