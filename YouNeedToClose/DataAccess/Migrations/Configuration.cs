namespace DataAccess.Migrations
{
    using DataAccess.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Models.TermContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Models.TermContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

 
            TermModel term = new TermModel();
            var startDate = DateTime.Now;
            var category = new List<CategoryModel>

            {
                new CategoryModel
                {NameOfCategory="Reliable Customer", Customers = new List<CustomerModel>
                    {
                        new CustomerModel{NameOfCompany="GameStop", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        }},
                        new CustomerModel{NameOfCompany="BestBuy", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        }},
                        new CustomerModel{NameOfCompany="Target", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        }}
                    }
                }
            };
            term.StartDate = startDate;
            term.Categories = category;
            term.BudgetActual = new BudgetActualModel
            {
                Budget = 0,
                Actual = 0,
                Difference = 0
            };

  
            
            using (var db = new TermContext())
            {
                db.Term.Add(term);
                db.SaveChanges();
            }
        }
    }
}
