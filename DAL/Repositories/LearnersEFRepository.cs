using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LearnersEFRepository : IRepository<Learner, string>
    {

        public string Add(Learner item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Learner item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Learner Get(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Learner> GetAll()
        {
            throw new NotImplementedException();
        }

        public Learner Save(Learner item)
        {
            throw new NotImplementedException();
        }
    }
}
