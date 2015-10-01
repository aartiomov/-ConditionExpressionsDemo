using DynamicExpressionsSample.Core;
using System;
using System.Linq;

namespace DynamicExpressionsSample.Common
{
    public class ConditionExpressionTree : DynamicExpression, IConditionExpression
    {
        #region IConditionExpression Members

        public virtual System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetConditionExpression()
        {
            var retVal = PredicateBuilder.True<IEvaluationContext>();
            foreach (var expression in Children.OfType<IConditionExpression>().Select(x => x.GetConditionExpression()).Where(x => x != null))
            {
                retVal = retVal.And(expression);
            }
            return retVal;
        }

        #endregion
    }
}