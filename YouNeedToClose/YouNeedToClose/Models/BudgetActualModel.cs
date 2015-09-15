using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouNeedToClose.Models
{
    public class BudgetActualModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;
        public double Budget { get; set; }
        public double Actual { get; set; }
        [NotMapped]
        public double Difference { get; set; }
    }
}