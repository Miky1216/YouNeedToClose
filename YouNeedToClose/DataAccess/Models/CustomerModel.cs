using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class CustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Customer Name")]
        public string NameOfCompany { get; set; }
        [DisplayName("Amount Budgeted")]
        public virtual BudgetActualModel BudgetActualCustomer { get; set; }
        public virtual List<DetailsCustomerModel> DetailsOfCustomer { get; set; }
    }
}