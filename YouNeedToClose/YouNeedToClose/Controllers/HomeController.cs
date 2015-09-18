using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        [HttpGet]
        public ActionResult EditCategory(int? id)
        {
            var editCategoryContext = new TermContext();
            
            if (id == null)
            {
                ;
            }
            TermModel term = editCategoryContext.Term.Find(id);
            if (term == null)
            {
                return HttpNotFound();
            }
            return View("EditCategoryView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Include="Id, NameOfCategory")] CategoryModel categoryModel)
        {
            var editCategoryContext = new TermContext();

            if (ModelState.IsValid)
            {
                editCategoryContext.Entry(categoryModel).State = EntityState.Modified;
                editCategoryContext.SaveChanges();
                return View("Index");
            }
            return View("EditCategoryView");
        }
        /*[HttpGet]
        public ActionResult Edit(int id)
        {
            using (var editCategoryContext = new TermContext())
            {
                return View(editCategoryContext.Term.Find(id));
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, TermModel Term)
        {
            using (var editCategoryContext = new TermContext())
            {
                editCategoryContext.Entry<TermModel>(Term).State =
                     System.Data.Entity.EntityState.Modified;
                editCategoryContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }*/
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
                //If the date does not exist, create it new and create any up until that point

                

            }
            else
            {
                //open term from database by id
                using (var db = new TermContext())
                {
                    term = db.Term.Find(id);
                    if(term==null)
                    {
                        term = GetNewTerm();
                        db.Term.Add(term);
                        db.SaveChanges();
                    }
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

        private TermModel GetNewTerm()
        {
            TermModel term = new TermModel();
            using (var db = new TermContext())
            {
               TermModel latestTerm = db.Term.OrderByDescending(e => e.Id).FirstOrDefault();
               
               term.PrevId = latestTerm.Id;
               term.StartDate = latestTerm.StartDate.AddMonths(1);
               term.ProjectedGoal = latestTerm.ProjectedGoal;
               term.Categories = new List<CategoryModel>();

               foreach(CategoryModel catm in latestTerm.Categories)//perform deep copy
               {
                   CategoryModel new_catm = new CategoryModel { NameOfCategory = catm.NameOfCategory,
                   Customers = new List<CustomerModel>()
                   };

                   foreach(CustomerModel custm in catm.Customers)
                   {
                       CustomerModel new_custm = new CustomerModel
                       {
                           NameOfCompany = custm.NameOfCompany,
                           BudgetActualCustomer = new BudgetActualModel { Budget = 0, Actual = 0, Difference = 0 }
                       };
                       new_catm.Customers.Add(new_custm);
                   }
                   term.Categories.Add(new_catm);
               }


    
                
            }
            return term;
        }
    }
}