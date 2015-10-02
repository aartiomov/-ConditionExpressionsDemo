using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    //Shopper first name []
    public class ConditionFirstNameIs : MatchedConditionBase<EvaluationContext>
    {
        public ConditionFirstNameIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.FirstName))
        {
        }
    }
}