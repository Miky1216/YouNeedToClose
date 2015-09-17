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

            #region temporary sample data
            TermModel term = new TermModel();
            var startDate = new DateTime(2015, 9, 1);
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
                },
                {
                    new CategoryModel{NameOfCategory="Easy Sale Customer", Customers = new List<CustomerModel>{
                        new CustomerModel{NameOfCompany="Kohls", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        }},
                        new CustomerModel{NameOfCompany="Costco", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        }},
                        new CustomerModel{NameOfCompany="WalMart", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        }}
                }
            }},
                {
                    new CategoryModel{NameOfCategory="Unreliable Customer", Customers = new List<CustomerModel>{
                        new CustomerModel{NameOfCompany="Woodmans", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        }},
                        new CustomerModel{NameOfCompany="Meijer", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=100
                        }},
                        new CustomerModel{NameOfCompany="PigglyWiggly", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=100
                        }}
                }
            }}
        };
            term.StartDate = startDate;
            term.Categories = category;
            term.BudgetActual = new BudgetActualModel
            {
                Budget = 0,
                Actual = 0,
                Difference = 0
            };

            #endregion
            
            using (var db = new TermContext())
            {
                db.Term.Add(term);
                db.SaveChanges();
            }
        }
    }
}
