using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    /// <summary>
    /// Condition to set age check
    /// </summary>
    public class ConditionOrdersIs : CompareConditionBase<EvaluationContext>
    {
        public ConditionOrdersIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.OrdersCount))
        {
            Value = "25";
        }
    }
}