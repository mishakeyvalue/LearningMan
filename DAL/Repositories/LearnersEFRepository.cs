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
        private LearnersContext _context;

        public LearnersEFRepository(LearnersContext context)
        {
            _context = context;
        }
        public string Add(Learner item)
        {
            _context.Learners.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void Delete(Learner item)
        {
            _context.Learners.Remove(item);
            _context.SaveChanges();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Learner Get(string Id)
        {
            return _context.Learners.Find(Id);
        }

        public ICollection<Learner> GetAll()
        {
            return _context.Learners.ToList();
        }

        public Learner Save(Learner item)
        {
            _context.SaveChanges();
            return item;
        }
    }
}
