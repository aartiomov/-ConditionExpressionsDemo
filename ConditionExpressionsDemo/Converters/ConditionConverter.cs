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
            var serializedTree = SerializationUtil.SerializeExpression(condition.GetConditionExpression());
            var serializedVisualTree = JsonConvert.SerializeObject(condition);

            return new Condition { Id = id, PredicateSerialized = serializedTree, VisualTreeSerialized = serializedVisualTree };
        }
    }
}