using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouNeedToClose.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {

            return TermDisplay(id);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ;
            }


            return View();
        }
        public ActionResult CreateNew(int? id)
        {
            if (id == null)
            {
                ;
            }

            return View("CreateNewCategoryView");
        }
        public ActionResult Delete()
        {

            return View();
        }
        public ActionResult Details()
        {

            return View();
        }
        public ActionResult TermDisplay(int? id)
        {
            TermModel term;
            if (id == null)
            {
                //determine which term is the current date


            }
            else
            {
                //open term from database by id

                //if term does not exist
                //copy categories and budgetted from previous term from database

            }


            #region temporary sample data
            term = new TermModel();
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

            foreach (CategoryModel termCategory in term.Categories)
            {
                termCategory.BudgetActualCategory = new BudgetActualModel
                {
                    Budget = 0,
                    Actual = 0,
                    Difference = 0
                };
                foreach (CustomerModel termCustomer in termCategory.Customers)
                {
                    termCategory.BudgetActualCategory.Budget += termCustomer.BudgetActualCustomer.Budget;
                    termCategory.BudgetActualCategory.Actual += termCustomer.BudgetActualCustomer.Actual;
                    termCategory.BudgetActualCategory.Difference += termCustomer.BudgetActualCustomer.Difference;
                }
                term.BudgetActual.Budget += termCategory.BudgetActualCategory.Budget;
                term.BudgetActual.Actual += termCategory.BudgetActualCategory.Actual;
                term.BudgetActual.Difference += termCategory.BudgetActualCategory.Difference;
            }

            var budgetActual = new BudgetActualModel
            {
                Budget = 500,
                Actual = 600,
                Difference = 100
            };

            var projectedMonthlyGoal = new ProjectedGoalModel
            {
                ExpectedAmountToEarn = 50000
            };

            return View("TermView", term);
        }
    }
}