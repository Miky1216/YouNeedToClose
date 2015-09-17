using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class TermContext : DbContext
    {
        public DbSet<TermModel> Term { get; set; }

        public System.Data.Entity.DbSet<DataAccess.Models.CategoryModel> CategoryModels { get; set; }
    }
}