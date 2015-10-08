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
            
            return View();
        }
        public ActionResult MonthOverview(int? id)
        {

            return TermDisplay(id ?? 1);
        }
        [HttpGet]
        public ActionResult ProjectedGoal(int? id, int? termID)
        {
            TempData["termId"] = id;

            return View("ProjectedGoalView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectedGoal([Bind(Include = "Id, ExpectedAmountToEarn")] ProjectedGoalModel projectedGoalModel)
        {
            var projectedGoalContext = new YNTCTermContext();
            int? termId = (int?)TempData["termId"];
            YNTCTermContext db = new YNTCTermContext();
            TermModel term = projectedGoalContext.Term.Find(termId);

            if (term == null)
            {
                term = GetNewTerm();
                db.Term.Add(term);
                db.SaveChanges();
            }
            term.ProjectedGoal = projectedGoalModel; 

            if (ModelState.IsValid)
            {
                projectedGoalContext.Entry(projectedGoalModel).State = EntityState.Added;
                projectedGoalContext.SaveChanges();
                return RedirectToAction("MonthOverview");
            }
            return View("ProjectedGoalView");
        }
        [HttpGet]
        public ActionResult EditCustomer(int? id, int? termID)
        {
            var editCustomerContext = new YNTCTermContext();
            TempData["termId"] = termID;

            TermModel term = editCustomerContext.Term.Find(id);
            CustomerModel cm = editCustomerContext.CustomerModels.Find(id);
            return View("EditCustomerView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "Id, NameOfCompany, BudgetActualCustomer")] CustomerModel customerModel)
        {
            var editCustomerContext = new YNTCTermContext();
            int? termId = (int?)TempData["termId"];

            var currentTerm = editCustomerContext.Term.Find(termId);

            if (ModelState.IsValid)
            {
                editCustomerContext.Entry(customerModel).State = EntityState.Modified;
                editCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview", currentTerm);
            }
            return View("SaleClosedView");
        }
        [HttpGet]
        public ActionResult SaleClosed(int? id, int? termID)
        {
            var saleClosedCustomerContext = new YNTCTermContext();
            TempData["termId"] = termID;

            TermModel term = saleClosedCustomerContext.Term.Find(id);
            CustomerModel cm = saleClosedCustomerContext.CustomerModels.Find(id);
            return View("SaleClosedView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaleClosed([Bind(Include = "Id, NameOfCompany, BudgetActualCustomer")] CustomerModel customerModel)
        {
            var saleClosedCustomerContext = new YNTCTermContext();
            int? termId = (int?)TempData["termId"];

            var currentTerm = saleClosedCustomerContext.Term.Find(termId);

            if (ModelState.IsValid)
            {
                saleClosedCustomerContext.Entry(customerModel).State = EntityState.Modified;
                saleClosedCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview", currentTerm);
            }
            return View("SaleClosedView");
        }
        [HttpGet]
        public ActionResult EditCategory(int? id, int? termID)
        {
            var editCategoryContext = new YNTCTermContext();
            TempData["termId"] = termID;
            
            TermModel term = editCategoryContext.Term.Find(id);
            CategoryModel cateModel = editCategoryContext.CategoryModels.Find(id);
            return View("EditCategoryView", cateModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Include="Id, NameOfCategory")] CategoryModel categoryModel)
        {
            var editCategoryContext = new YNTCTermContext();
            int? termId = (int?)TempData["termId"];

            var currentTerm = editCategoryContext.Term.Find(termId);

            if (ModelState.IsValid)
            {
                editCategoryContext.Entry(categoryModel).State = EntityState.Modified;
                editCategoryContext.SaveChanges();
                return RedirectToAction("MonthOverview", currentTerm);
            }
            return View("EditCategoryView");
        }
        [HttpGet]
        public ActionResult CreateNewCategory(int? id)
        {
            var createCategoryContext = new YNTCTermContext();

            TempData["termId"] = id;
            CategoryModel cm = createCategoryContext.CategoryModels.Find(id);
            return View("CreateNewCategoryView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewCategory(CategoryModel categoryModel)
        {
            var createCategoryContext = new YNTCTermContext();
            int? termId = (int?)TempData["termId"];

            var currentTerm = createCategoryContext.Term.Find(termId);

            //TermModel term = createCategoryContext.Term.Find(termId);
            currentTerm.Categories.Add(categoryModel);

            if (ModelState.IsValid)
            {
                createCategoryContext.Entry(categoryModel).State = EntityState.Added;
                createCategoryContext.SaveChanges();
                return RedirectToAction("MonthOverview", currentTerm);
            }
            return View("CreateNewCategoryView", categoryModel);
        }
        [HttpGet]
        public ActionResult CreateNewCustomer(int? id, int? termID)
        {
            TempData["categoryModel"] = id;

            return View("CreateNewCustomerView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewCustomer(CustomerModel customerModel)
        {
            var createCustomerContext = new YNTCTermContext();
            int? categoryModel = (int?)TempData["categoryModel"];

            var currentTerm = createCustomerContext.Term.Find(categoryModel);

            CategoryModel modelOfCategory = createCustomerContext.CategoryModels.Find(categoryModel);
            modelOfCategory.Customers.Add(customerModel);

            if (ModelState.IsValid)
            {
                createCustomerContext.Entry(customerModel).State = EntityState.Added;
                createCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview", currentTerm);
            }
            return View("CreateNewCustomerView");
        }
        [HttpGet]
        public ActionResult DeleteCustomer(int? id, int ? termID)
        {
            var deleteCustomerContext = new YNTCTermContext();
            TempData["termId"] = termID;

            TermModel term = deleteCustomerContext.Term.Find(id);
            CustomerModel cm = deleteCustomerContext.CustomerModels.Find(id);
            return View("DeleteCustomerView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer([Bind(Include = "Id, NameOfCompany, BudgetActualCustomer")] CustomerModel customerModel)
        {
            var deleteCustomerContext = new YNTCTermContext();
            int? termId = (int?)TempData["termId"];

            var currentTerm = deleteCustomerContext.Term.Find(termId);

            if (ModelState.IsValid)
            {
                deleteCustomerContext.Entry(customerModel).State = EntityState.Deleted;
                deleteCustomerContext.CustomerModels.Remove(customerModel);
                deleteCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview", currentTerm);
            }
            return View("DeleteCustomerView");
        }
        [HttpGet]
        public ActionResult DeleteCategory(int? id, int? termID)
        {
            var deleteCategoryContext = new YNTCTermContext();
            TempData["termId"] = termID;

            //TermModel term = deleteCategoryContext.Term.Find(id);
            CategoryModel cm = deleteCategoryContext.CategoryModels.Find(id);
            return View("DeleteCategoryView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory([Bind(Include = "Id, NameOfCategory")] CategoryModel categoryModel)
        {
            var deleteCategoryContext = new YNTCTermContext();
            int? termId = (int?)TempData["termId"];

            var currentTerm = deleteCategoryContext.Term.Find(termId);

            if (ModelState.IsValid)
            {
                deleteCategoryContext.Entry(categoryModel).State = EntityState.Deleted;
                deleteCategoryContext.CategoryModels.Remove(categoryModel);
                deleteCategoryContext.SaveChanges();
                return RedirectToAction("MonthOverview", currentTerm);
            }
            return View("DeleteCategoryView");
        }

        [HttpGet]
        public ActionResult DetailsCustomer(int? id, int? termID)
        {
            var createDetailsContext = new YNTCTermContext();

            TempData["termId"] = termID;
            DetailsCustomerModel dm = createDetailsContext.CustomerModels.Find(id).DetailsOfCustomer;
            return View("DetailsCustomerView", dm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailsCustomer([Bind(Include = "Id, ContactName, CustomerMotivations")]CustomerModel customerModel, DetailsCustomerModel detailsModel)
        {
            var createDetailsContext = new YNTCTermContext();
            int? termId = (int?)TempData["termId"];

            //var currentTerm = createDetailsContext.Term.Find(termId);

            //TermModel term = createDetailsContext.Term.Find(termId);
            var detailsOnCustomerId = createDetailsContext.CustomerModels.Find(customerModel.Id);
            detailsOnCustomerId.DetailsOfCustomer = detailsModel;
             

            if (ModelState.IsValid)
            {
                createDetailsContext.Entry(detailsModel).State = EntityState.Added;
                createDetailsContext.SaveChanges();
                RedirectToAction("MonthOverview", detailsModel);
            }
            return View("DetailsCustomerView", detailsModel);
        }

        public ActionResult TermDisplay(int? id)
        {
            
            TermModel term = new TermModel();
            if (id == null)
            {
                //determine which term is the current date
                //If the date does not exist, create it new and create any up until that point

            }
            else
            {
                //open term from database by id
                using (var db = new YNTCTermContext())
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
                    
                    //if term does not exist
                    //copy categories and budgeted from previous term from database
                    
                   term.ProjectedGoal.ExpectedAmountToEarn = (term.ProjectedGoal.ExpectedAmountToEarn + term.ProjectedGoal.ExpectedAmountToEarn) / 2;
                }
            }
           return View("TermView", term);
        }

        private TermModel GetNewTerm()
        {
            TermModel term = new TermModel();
            using (var db = new YNTCTermContext())
            {
                TermModel latestTerm = db.Term.OrderByDescending(e => e.Id).FirstOrDefault();
               
                term.PrevId = latestTerm.Id;
                //term.NextId = term.Id;
                db.SaveChanges();   
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