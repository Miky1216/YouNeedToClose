using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YouNeedToClose.Models;


namespace YouNeedToClose.Models 
{
    public class YNTCUserContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<TermModel> Term { get; set; }
        public DbSet<DetailsCustomerModel> DetailsCustomer { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public System.Data.Entity.DbSet<YouNeedToClose.Models.CategoryModel> CategoryModels { get; set; }
        public System.Data.Entity.DbSet<YouNeedToClose.Models.CustomerModel> CustomerModels { get; set; }
    }
}