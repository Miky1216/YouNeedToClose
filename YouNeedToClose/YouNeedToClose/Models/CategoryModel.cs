using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouNeedToClose.Models
{
    public class CategoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string NameOfCategory { get; set; }
        public virtual List<CustomerModel> Customers { get; set; }
        [NotMapped]
        public virtual BudgetActualModel BudgetActualCategory { get; set; }
    }
}