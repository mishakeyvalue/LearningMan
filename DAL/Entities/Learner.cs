using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Learner : IEntity<string>
    {
        public string Id { get; set; }
        public List<LearnersCard> Cards { get; set; }
    }
}
