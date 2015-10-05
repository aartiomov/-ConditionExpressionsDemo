using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Core;
using System;
using System.Linq;

namespace ConditionExpressionsDemo.Conditions
{
    /// <summary>
    /// Root and/or condition
    /// </summary>
    public class BlockConditionAndOr : DynamicExpression, IConditionExpression
    {
        public bool All { get; set; }
        #region IConditionExpression Members

        public System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetConditionExpression()
        {
            System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> retVal = null;
            if (Children != null && Children.Any())
            {
                //If All is true set PredicateBuilder for all conditions to return true
                retVal = All ? PredicateBuilder.True<IEvaluationContext>() : PredicateBuilder.False<IEvaluationContext>();

                //collect expressions from children conditions join them with or/and depending on All property value
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