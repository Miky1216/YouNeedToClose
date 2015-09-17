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
        public virtual List<CategoryModel> Categories { get; set; }
        [NotMapped]
        public virtual BudgetActualModel BudgetActual { get; set; }
        public virtual ProjectedGoalModel ProjectedGoal { get; set; }
        public virtual TermModel NextTerm {get;set;}
        public virtual TermModel PreviousTerm { get; set; }
   }
}