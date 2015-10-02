using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    /// <summary>
    /// Condition to set last name check
    /// </summary>
    public class ConditionLastNameIs : MatchedConditionBase<EvaluationContext>
    {
        public ConditionLastNameIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.LastName))
        {
        }
    }
}