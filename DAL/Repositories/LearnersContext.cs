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
        private static string _conString = "Server=tcp:studymanager.database.windows.net,1433;Initial Catalog=StudyMan;Persist Security Info=False;User ID=mitutee;Password=Hardware2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public LearnersContext() : base(_conString)
        {
            //string conString  = System.Configuration.ConfigurationManager.
            //        ConnectionStrings["Test"].ConnectionString;
            //Database.Connection.ConnectionString = conString;
        }

        public LearnersContext(string connectionString) : base(connectionString)
        {}

        public DbSet<Learner> Learners { get; set; }
    }
}
