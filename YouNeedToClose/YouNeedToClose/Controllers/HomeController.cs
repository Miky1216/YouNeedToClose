﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouNeedToClose.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return TermDisplay();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TermDisplay()
        {
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
        foreach(CategoryModel termCategory in term.Categories)
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
                Budget=500, Actual=600, Difference=100
            };

            var projectedMonthlyGoal = new ProjectedGoalModel
            {
                ExpectedAmountToEarn=50000
            };

            return View("TermView", term);
        }
    }
}