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
        [DisplayFormat(DataFormatString = "{0:MMMM}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public virtual List<CategoryModel> Categories { get; set; }
        [NotMapped]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public virtual BudgetActualModel BudgetActual { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public virtual ProjectedGoalModel ProjectedGoal { get; set; }
        public virtual DetailsCustomerModel DetailsCustomer { get; set; }
        public int NextId { get; set; }
        public int PrevId { get; set; }
   }
}