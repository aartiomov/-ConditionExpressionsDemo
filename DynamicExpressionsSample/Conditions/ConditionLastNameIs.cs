using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    //Shopper last name []
    public class ConditionLastNameIs : MatchedConditionBase<EvaluationContextBase>
    {
        public ConditionLastNameIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContextBase>(x => x.LastName))
        {
        }
    }
}