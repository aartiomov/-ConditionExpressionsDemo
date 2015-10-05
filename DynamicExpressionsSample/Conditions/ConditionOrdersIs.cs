using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Core;
using System;
using linq = System.Linq.Expressions;

namespace ConditionExpressionsDemo.Conditions
{
    /// <summary>
    /// Condition to set orders count check
    /// </summary>
    public class ConditionOrdersIs : DynamicExpression, IConditionExpression
    {
        public int Value { get; set; }

        public bool Exactly { get; set; }

        #region IConditionExpression Members
        /// <summary>
        /// ((EvaluationContext)x).OrdersCount > Value
        /// </summary>
        /// <returns></returns>
        linq.Expression<Func<IEvaluationContext, bool>> IConditionExpression.GetConditionExpression()
        {
            linq.ParameterExpression paramX = linq.Expression.Parameter(typeof(IEvaluationContext), "x");
            var castOp = linq.Expression.MakeUnary(linq.ExpressionType.Convert, paramX, typeof(EvaluationContext));
            var propertyValue = linq.Expression.Property(castOp, typeof(EvaluationContext).GetProperty(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.OrdersCount)));
                     
            var numItem = linq.Expression.Constant(Value);
            var binaryOp = Exactly ? linq.Expression.Equal(propertyValue, numItem) : linq.Expression.GreaterThanOrEqual(propertyValue, numItem);

            var retVal = linq.Expression.Lambda<Func<IEvaluationContext, bool>>(binaryOp, paramX);
            return retVal;
        }

        #endregion
    }
}