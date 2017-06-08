using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LearnersContext : DbContext
    {
        public LearnersContext() : base("LearnersContext")
        {
            var r = System.Configuration.ConfigurationManager.
                    ConnectionStrings.Count;

            string conString  = System.Configuration.ConfigurationManager.
                    ConnectionStrings["Test"].ConnectionString;
            Database.Connection.ConnectionString = conString;
        }

        public DbSet<Learner> Learners { get; set; }
    }
}
