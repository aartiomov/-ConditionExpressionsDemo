using ConditionExpressionsDemo.Core;
using System;
using System.Linq;

namespace ConditionExpressionsDemo.Common
{
    public class ConditionExpressionTree : DynamicExpression, IConditionExpression
    {
        #region IConditionExpression Members

        public virtual System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetConditionExpression()
        {
            var predicate = PredicateBuilder.True<IEvaluationContext>();
            foreach (var expression in Children.OfType<IConditionExpression>().Select(x => x.GetConditionExpression()).Where(x => x != null))
            {
                predicate = predicate.And(expression);
            }
            return predicate;
        }

        #endregion
    }
}