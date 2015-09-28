using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YouNeedToClose.Models;
using Microsoft.AspNet.Identity;

namespace YouNeedToClose.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationSignInManager signInManager;
        public ApplicationUserManager userManager;
        public ActionResult Index(int? id)
        {
            
            return View();
        }
        public ActionResult MonthOverview(int? id)
        {

            return TermDisplay(id ?? 1);
        }

        [HttpGet]
        public ActionResult ProjectedGoal(int? id)
        {
            TempData["termId"] = id;

            return View("ProjectedGoalView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectedGoal([Bind(Include = "Id, ExpectedAmountToEarn")] ProjectedGoalModel projectedGoalModel)
        {
            var projectedGoalContext = new TermContext();
            int? termId = (int?)TempData["termId"];

            TermModel term = projectedGoalContext.Term.Find(termId);
            if (term == null)
            {
                term = GetNewTerm();
                projectedGoalContext.Term.Add(term);
                projectedGoalContext.SaveChanges();
            }
            term.ProjectedGoal = projectedGoalModel;

            if (ModelState.IsValid)
            {
                projectedGoalContext.Entry(projectedGoalModel).State = EntityState.Added;
                projectedGoalContext.SaveChanges();
                return RedirectToAction("MonthOverview");
            }
            return View("ProjectedGoalView".ToList());
        }

        [HttpGet]
        public ActionResult EditCustomer(int? id)
        {
            var editCustomerContext = new TermContext();

            TermModel term = editCustomerContext.Term.Find(id);
            CustomerModel cm = editCustomerContext.CustomerModels.Find(id);
            return View("EditCustomerView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "Id, NameOfCompany, BudgetActualCustomer")] CustomerModel customerModel)
        {
            var editCustomerContext = new TermContext();

            if (ModelState.IsValid)
            {
                editCustomerContext.Entry(customerModel).State = EntityState.Modified;
                editCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview");
            }
            return View("EditCustomerView");
        }

        [HttpGet]
        public ActionResult SaleClosed(int? id)
        {
            var saleClosedCustomerContext = new TermContext();

            TermModel term = saleClosedCustomerContext.Term.Find(id);
            CustomerModel cm = saleClosedCustomerContext.CustomerModels.Find(id);
            return View("SaleClosedView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaleClosed([Bind(Include = "Id, NameOfCompany, BudgetActualCustomer")] CustomerModel customerModel)
        {
            var saleClosedCustomerContext = new TermContext();

            if (ModelState.IsValid)
            {
                saleClosedCustomerContext.Entry(customerModel).State = EntityState.Modified;
                saleClosedCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview");
            }
            return View("SaleClosedView");
        }

        [HttpGet]
        public ActionResult EditCategory(int? id)
        {
            var editCategoryContext = new TermContext();
            
            TermModel term = editCategoryContext.Term.Find(id);
            CategoryModel cateModel = editCategoryContext.CategoryModels.Find(id);
            return View("EditCategoryView", cateModel);
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
                return RedirectToAction("MonthOverview");
            }
            return View("EditCategoryView");
        }

        [HttpGet]
        public ActionResult CreateNewCategory(int? id)
        {
            TempData["termId"] = id;

            return View("CreateNewCategoryView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewCategory(CategoryModel categoryModel)
        {
            var createCategoryContext = new TermContext();
            int? termId = (int?)TempData["termId"];

            TermModel term = createCategoryContext.Term.Find(termId);
            term.Categories.Add(categoryModel);

            if (ModelState.IsValid)
            {
                createCategoryContext.Entry(categoryModel).State = EntityState.Added;
                createCategoryContext.SaveChanges();
                return RedirectToAction("MonthOverview");
            }
            return View("CreateNewCategoryView");
        }

        [HttpGet]
        public ActionResult CreateNewCustomer(int? id)
        {
            TempData["categoryModel"] = id;

            return View("CreateNewCustomerView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewCustomer(CustomerModel customerModel)
        {
            var createCustomerContext = new TermContext();
            int? categoryModel = (int?)TempData["categoryModel"];

            CategoryModel modelOfCategory = createCustomerContext.CategoryModels.Find(categoryModel);
            modelOfCategory.Customers.Add(customerModel);

            if (ModelState.IsValid)
            {
                createCustomerContext.Entry(customerModel).State = EntityState.Added;
                createCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview");
            }
            return View("CreateNewCustomerView");
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int? id)
        {
            var deleteCustomerContext = new TermContext();

            TermModel term = deleteCustomerContext.Term.Find(id);
            CustomerModel cm = deleteCustomerContext.CustomerModels.Find(id);
            return View("DeleteCustomerView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer([Bind(Include = "Id, NameOfCompany, BudgetActualCustomer")] CustomerModel customerModel)
        {
            var deleteCustomerContext = new TermContext();

            if (ModelState.IsValid)
            {
                deleteCustomerContext.Entry(customerModel).State = EntityState.Deleted;
                deleteCustomerContext.CustomerModels.Remove(customerModel);
                deleteCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview");
            }
            return View("DeleteCustomerView");
        }

        [HttpGet]
        public ActionResult DeleteCategory(int? id)
        {
            var deleteCategoryContext = new TermContext();

            TermModel term = deleteCategoryContext.Term.Find(id);
            CategoryModel cm = deleteCategoryContext.CategoryModels.Find(id);
            return View("DeleteCategoryView", cm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory([Bind(Include = "Id, NameOfCategory")] CategoryModel categoryModel)
        {
            var deleteCustomerContext = new TermContext();

            if (ModelState.IsValid)
            {
                deleteCustomerContext.Entry(categoryModel).State = EntityState.Deleted;
                deleteCustomerContext.CategoryModels.Remove(categoryModel);
                deleteCustomerContext.SaveChanges();
                return RedirectToAction("MonthOverview");
            }
            return View("DeleteCategoryView");
        }

        [HttpGet]
        public ActionResult DetailsCustomer(int? id, int ? termID)
        {
            var createDetailsContext = new TermContext();

            TempData["termId"] = termID;
            DetailsCustomerModel dm = createDetailsContext.DetailsCustomer.Find(id);
            return View("DetailsCustomerView", dm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailsCustomer([Bind(Include = "Id, ContactName, CustomerMotivations")]DetailsCustomerModel detailsModel)
        {
            var createDetailsContext = new TermContext();
            int? termId = (int?)TempData["termId"];

            TermModel term = createDetailsContext.Term.Find(termId);
            term.DetailsCustomer = detailsModel;

            if (ModelState.IsValid)
            {
                createDetailsContext.Entry(detailsModel).State = EntityState.Added;
                createDetailsContext.SaveChanges();
           //   RedirectToAction("DetailsCustomerView", detailsModel);
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
                    //if term does not exist
                    //copy categories and budgetted from previous term from database
                    term.ProjectedGoal.ExpectedAmountToEarn = (term.ProjectedGoal.ExpectedAmountToEarn + term.ProjectedGoal.ExpectedAmountToEarn) / 2;
                }
            }
           return View("TermView", term);
        }
        public ApplicationDbContext ApplicationDbContext { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }
        
        private TermModel GetNewTerm()
        {
            using (ApplicationDbContext c = new ApplicationDbContext())
            {
                var user = c.Users.Find(User.Identity.GetUserId());
                ((ApplicationUser)user).Terms.Add(new TermModel());

                var applicationUser = user.Terms.OrderByDescending(a => a.Id);                    

                TermModel term = new TermModel();
                //TermModel latestTerm = db.Term.OrderByDescending(e => e.Id).FirstOrDefault(); ---What it was before context change
                //TermModel latestTerm = user.Terms.OrderByDescending(e => e.Id).FirstOrDefault(); ---What it was changed to
                TermModel latestTerm = user.Terms.OrderByDescending(e => e.Id).FirstOrDefault();

                user.Terms.Add(term);
                c.SaveChanges();
                term.PrevId = latestTerm.Id;
                term.NextId = null;

                //term.StartDate = latestTerm.StartDate.AddMonths(1);
                term.StartDate = DateTime.Now.AddMonths(1);
                term.ProjectedGoal = latestTerm.ProjectedGoal;
                
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
                            BudgetActualCustomer = new BudgetActualModel { Budget = 0, Actual = 0, Difference = 0 },
                        };
                        new_catm.Customers.Add(new_custm);
                    }
                    term.Categories.Add(new_catm);
                }
                return term;
            }
        }
    }
}