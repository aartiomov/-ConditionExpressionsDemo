using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;
using System;
using System.Linq;

namespace DynamicExpressionsSample.Conditions
{
    public class BlockConditionAndOr : DynamicExpression, IConditionExpression
    {
        public bool All { get; set; }
        #region IConditionExpression Members

        public System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetConditionExpression()
        {
            System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> retVal = null;
            if (Children != null && Children.Any())
            {
                retVal = All ? PredicateBuilder.True<IEvaluationContext>() : PredicateBuilder.False<IEvaluationContext>();
                foreach (var expression in Children.OfType<IConditionExpression>().Select(x => x.GetConditionExpression()))
                {
                    retVal = All ? retVal.And(expression) : retVal.Or(expression);
                }
            }
            return retVal;
        }

        #endregion


    }
}