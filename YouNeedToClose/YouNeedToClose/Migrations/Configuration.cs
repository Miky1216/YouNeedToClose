using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using YouNeedToClose.Models;

namespace YouNeedToClose.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<YouNeedToClose.Models.YNTCUserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(YouNeedToClose.Models.YNTCUserContext context)
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

             using (var db = new YNTCUserContext())
             {
                 db.Term.Add(term);
                 db.SaveChanges();
             }
         }
    }
}
