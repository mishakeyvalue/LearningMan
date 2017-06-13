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

        private static LearnersManager _instance;
        public static LearnersManager Instance 
        {
            get {
                if (_instance == null) _instance = GetManager();
                return _instance;
            }
        }

        private readonly IRepository<Learner, string> _repository;

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
           if (learner.Cards == null) learner.Cards = new List<LearnersCard>();
           learner.Cards.Add(card);
           _repository.Save(learner);


        }

        private Learner ensureUserExists(string learnerId)
        {
            Learner learner = _repository.GetAll().FirstOrDefault(l => l.Id.Equals(learnerId));

            if (learner == null)
            {
                learner = createLearner(learnerId);
            }

            return learner;
        }

        private Learner createLearner(string learnerId)
        {
            var learner = new Learner
            {
                Id = learnerId,
                Cards = new List<LearnersCard>()
            };
            var helloCard = new LearnersCard()
            {
                Key = "Hello world!",
                Value = "Привет, мир!",
                LastRepetition = DateTime.Now,
                Rating = 12,
                Learner = learner
            };
            learner.Cards.Add(helloCard);
            _repository.Add(learner);
            return learner;

        }

        public int CountCards(string learnerId)
        {
            try
            {

                return _repository.Get(learnerId).Cards.Count;
            }
            catch (NullReferenceException)
            {
                createLearner(learnerId);
                return 0;
            }
        }
    }
}