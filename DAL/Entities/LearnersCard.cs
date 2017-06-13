using System;

namespace DAL.Entities
{
    public class LearnersCard
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime LastRepetition { get; set; }
        public byte Rating { get; set; }

        public Learner Learner { get; set; }

    }
}