namespace YouNeedToClose.Migrations
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
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataAccess.Models.TermContext context)
        {
            var startDate = new DateTime(2015, 9, 1);
            TermModel term = new TermModel();

            var category = new List<CategoryModel>
                {
                    new CategoryModel
                    {
                        NameOfCategory = "Reliable Customer", Customers = new List<CustomerModel>
                        {
                            new CustomerModel{NameOfCompany="Company Name Example", BudgetActualCustomer = new BudgetActualModel
                            {
                                Budget = 0, Actual = 0, Difference = 0
                            }}
                        }
                    }
                };
            term.StartDate = startDate;
            term.Categories = category;
            
            using (var db = new TermContext())
            {
                db.Term.Add(term);
                db.SaveChanges();
            }
        }
    }
}
