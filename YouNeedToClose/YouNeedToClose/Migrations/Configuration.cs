namespace YouNeedToClose.Migrations
{
    using DataAccess.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Models.TermContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Models.TermContext context)
        {

            TermModel term = new TermModel();
            var startDate = new DateTime(2015, 9, 1);

            using (var db = new TermContext())
            {
                db.Term.Add(term);
                db.SaveChanges();
            }
        }
    }
}
