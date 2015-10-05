using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;
using System;
using linq = System.Linq.Expressions;

namespace DynamicExpressionsSample.Conditions
{
    /// <summary>
    /// Condition to set age check
    /// </summary>
    public class ConditionOrdersIs : DynamicExpression, IConditionExpression
    {
        public int NumItem { get; set; }

        public bool Exactly { get; set; }

        #region IConditionExpression Members
        /// <summary>
        /// ((EvaluationContext)x).OrdersCount > NumItem
        /// </summary>
        /// <returns></returns>
        linq.Expression<Func<IEvaluationContext, bool>> IConditionExpression.GetConditionExpression()
        {
            linq.ParameterExpression paramX = linq.Expression.Parameter(typeof(IEvaluationContext), "x");
            var castOp = linq.Expression.MakeUnary(linq.ExpressionType.Convert, paramX, typeof(EvaluationContext));
            var propertyValue = linq.Expression.Property(castOp, typeof(EvaluationContext).GetProperty(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.OrdersCount)));
                     
            var numItem = linq.Expression.Constant(NumItem);
            var binaryOp = Exactly ? linq.Expression.Equal(propertyValue, numItem) : linq.Expression.GreaterThanOrEqual(propertyValue, numItem);

            var retVal = linq.Expression.Lambda<Func<IEvaluationContext, bool>>(binaryOp, paramX);
            return retVal;
        }

        #endregion
    }
}