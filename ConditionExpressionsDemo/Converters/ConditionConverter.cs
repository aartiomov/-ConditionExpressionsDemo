using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ConditionExpressionsDemo.Converters
{
    public static class ConditionConverter
    {
        public static Condition ToCondition(this ConditionExpressionTree condition, string id)
        {
            //serialize expression predicate
            var serializedTree = SerializationUtil.SerializeExpression(condition.GetConditionExpression());

            //serialize visual tree to json
            var serializedVisualTree = JsonConvert.SerializeObject(condition);

            //return condition object
            return new Condition { Id = id, PredicateSerialized = serializedTree, VisualTreeSerialized = serializedVisualTree };
        }
    }
}