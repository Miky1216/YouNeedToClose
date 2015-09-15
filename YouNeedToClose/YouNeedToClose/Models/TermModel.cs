using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouNeedToClose.Models
{
    public class TermModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;
        public DateTime StartDate;
        public DateTime EndDate;
        public virtual List<CategoryModel> Categories;
        public virtual List<CustomerModel> Customers;
        public virtual BudgetActualModel BudgetActual;
        public virtual ProjectedGoalModel ProjectedGoal;
   }
}