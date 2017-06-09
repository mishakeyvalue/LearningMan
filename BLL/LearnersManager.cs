using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Utility class that encapsulates main logic
    /// for manipulating user data
    /// </summary>
    public class LearnersManager
    {
        public static LearnersManager GetManager()
        {
            var context = new LearnersContext();
            LearnersEFRepository repo = new LearnersEFRepository(context);
            return new LearnersManager(repo);
        }

        private IRepository<Learner, string> _repository;
        public LearnersManager(IRepository<Learner, string> repository)
        {
            _repository = repository;
        }

        public void AddCard(string key, string value, string learnerId)
        {
           Learner learner = ensureUserExists(learnerId);
            LearnersCard card = new LearnersCard()
            {
                Key = key,
                Value = value,
                LastRepetition = DateTime.Now,
                Rating = 1
            };
            learner.Cards.Add(card);
            _repository.Save(learner);


        }

        private Learner ensureUserExists(string learnerId)
        {
            Learner learner = _repository.GetAll().First(l => l.Id.Equals(learnerId));
            if (learner == null) {
                learner = new Learner() { Id = learnerId };
                _repository.Add(learner);
            }
            return learner;
        }
    }
}
