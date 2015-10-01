using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    //Shopper gender is []
    public class ConditionGenderIs : MatchedConditionBase<EvaluationContextBase>
    {
        public ConditionGenderIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContextBase>(x => x.ShopperGender))
        {
            Value = "female";
        }
    }
}