using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    /// <summary>
    /// Condition to set name of the customer check
    /// </summary>
    public class ConditionFirstNameIs : MatchedConditionBase<EvaluationContext>
    {
        public ConditionFirstNameIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.FirstName))
        {
        }
    }
}