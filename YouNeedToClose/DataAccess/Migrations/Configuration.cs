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
 
            TermModel term = new TermModel();
            DetailsCustomerModel detailsCustomer = new DetailsCustomerModel();
            var startDate = new DateTime(2015, 9, 1);
            var category = new List<CategoryModel>
            {
                new CategoryModel
                {NameOfCategory="Reliable Customer", Customers = new List<CustomerModel>
                    {
                        new CustomerModel{NameOfCompany="GameStop", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        },
                            DetailsOfCustomer = new List<DetailsCustomerModel>
                            {
                                new DetailsCustomerModel{ ContactName = "John Smith", CustomerMotivations = "This is my motivation for the sale."}
                            }
                        },
                        new CustomerModel{NameOfCompany="BestBuy", BudgetActualCustomer = new BudgetActualModel
                        {
                            Budget=800, Actual=1000, Difference=200
                        },
                            DetailsOfCustomer = new List<DetailsCustomerModel>
                            {
                                new DetailsCustomerModel{ContactName = "Adam Apple", CustomerMotivations = "Here are my motivations."}
                            }
                        },
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
            }},
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
                db.DetailsCustomer.Add(detailsCustomer);
                db.SaveChanges();
            }
        }
    }
}
