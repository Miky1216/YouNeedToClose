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
        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                ;
            }


            return View("EditCustomerView");
        }
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                ;
            }


            return View();
        }
        public ActionResult CreateNewCategory(int? id)
        {
            if (id == null)
            {
                ;
            }

            return View("CreateNewCategoryView");
        }
        public ActionResult CreateNewCustomer(int? id)
        {
            if (id == null)
            {
                ;
            }

            return View("CreateNewCustomerView");
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
            id = 1;
            TermModel term = new TermModel();
            if (id == null)
            {
                //determine which term is the current date


            }
            else
            {
                //open term from database by id
                using (var db = new TermContext())
                {
                    term = db.Term.Find(id);
                    term.BudgetActual = new BudgetActualModel
                    {
                        Budget = 0,
                        Actual = 0,
                        Difference = 0
                    };
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
                            termCustomer.BudgetActualCustomer.Difference = termCustomer.BudgetActualCustomer.Actual - termCustomer.BudgetActualCustomer.Budget;
                            
                            termCategory.BudgetActualCategory.Budget += termCustomer.BudgetActualCustomer.Budget;
                            termCategory.BudgetActualCategory.Actual += termCustomer.BudgetActualCustomer.Actual;
                            termCategory.BudgetActualCategory.Difference += termCustomer.BudgetActualCustomer.Difference;
                            
                        }
                        term.BudgetActual.Budget += termCategory.BudgetActualCategory.Budget;
                        term.BudgetActual.Actual += termCategory.BudgetActualCategory.Actual;
                        term.BudgetActual.Difference += termCategory.BudgetActualCategory.Difference;
                    }
                    var projectedMonthlyGoal = new ProjectedGoalModel
                    {
                        ExpectedAmountToEarn = 50000
                    };
                    //if term does not exist
                    //copy categories and budgetted from previous term from database
                }
            }
           return View("TermView", term);
        }
    }
}