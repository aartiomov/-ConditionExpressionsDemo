

using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    //Age is []
    public class ConditionAgeIs : CompareConditionBase<EvaluationContextBase>
    {
        public ConditionAgeIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContextBase>(x => x.ShopperAge))
        {
            Value = "25";
        }
    }
}