

using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    //Age is []
    public class ConditionAgeIs : CompareConditionBase<EvaluationContext>
    {
        public ConditionAgeIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.ShopperAge))
        {
            Value = "25";
        }
    }
}