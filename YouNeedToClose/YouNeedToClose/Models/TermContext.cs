using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YouNeedToClose.Models
{
    public class TermContext : DbContext
    {
        public DbSet<ProjectedGoalModel> ProjectedGoal { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<BudgetActualModel> BudetActual { get; set; }
    }
}