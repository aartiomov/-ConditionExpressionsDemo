using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    //Shopper last name []
    public class ConditionLastNameIs : MatchedConditionBase<EvaluationContext>
    {
        public ConditionLastNameIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.LastName))
        {
        }
    }
}