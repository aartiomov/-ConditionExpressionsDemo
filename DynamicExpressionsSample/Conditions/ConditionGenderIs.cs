using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    //Shopper gender is []
    public class ConditionGenderIs : MatchedConditionBase<EvaluationContext>
    {
        public ConditionGenderIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.ShopperGender))
        {
            Value = "female";
        }
    }
}