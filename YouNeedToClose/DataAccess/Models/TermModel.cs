using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class TermModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual List<CategoryModel> Categories { get; set; }
        public virtual List<CustomerModel> Customers { get; set; }
        [NotMapped]
        public virtual BudgetActualModel BudgetActual { get; set; }
        public virtual ProjectedGoalModel ProjectedGoal { get; set; }
   }
}