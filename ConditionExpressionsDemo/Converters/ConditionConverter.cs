using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Core;
using ConditionExpressionsDemo.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Linq;

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

        public static ConditionExpressionTree ToInitialCondition(this ConditionExpressionTree deserializedCondition, ConditionExpressionTree initial)
        {
            //Fill AvailableChildren property by copying them from the initial because they not persisted while saving to reduce the serialized object
            var sourceBlocks = (initial as DynamicExpression).Traverse(x => x.Children);
            var targetBlocks = (deserializedCondition as DynamicExpression).Traverse(x => x.Children);
            foreach (var sourceBlock in sourceBlocks)
            {
                foreach (var targetBlock in targetBlocks.Where(x => x.Id == sourceBlock.Id))
                {
                    targetBlock.AvailableChildren = sourceBlock.AvailableChildren;
                }
            }

            //copy available elements from etalon
            deserializedCondition.AvailableChildren = initial.AvailableChildren;

            return deserializedCondition;
        }
    }
}