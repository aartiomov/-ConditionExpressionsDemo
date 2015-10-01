using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    //Shopper first name []
    public class ConditionFirstNameIs : MatchedConditionBase<EvaluationContextBase>
    {
        public ConditionFirstNameIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContextBase>(x => x.FirstName))
        {
        }
    }
}