using ConditionExpressionsDemo.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace ConditionExpressionsDemo.Repository
{
    public class InMemoryConditionService : IConditionService
    {
        private readonly List<Condition> _store;

        public InMemoryConditionService()
        {
            _store = new List<Condition>();
        }

        public IEnumerable<Condition> Conditions
        {
            get { return _store; }
        }

        public void Add(Condition condition)
        {
            _store.Add(condition);
        }

        public Condition GetById(string id)
        {
            return _store.FirstOrDefault(condition => condition.Id.Equals(id));
        }
    }
}