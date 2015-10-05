using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Domain.Model;
using System.Collections.Generic;

namespace ConditionExpressionsDemo.Repository
{
    public interface IConditionService
    {
        IEnumerable<Condition> Conditions { get; }
        void Add(Condition condition);
        Condition GetById(string id);
    }
}
