using System;

namespace DAL.Entities
{
    public class LearnersCard
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime LastRepetition { get; set; }

        public byte Rating { get; set; }
    }
}