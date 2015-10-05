using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Core;

namespace DynamicExpressionsSample.Conditions
{
    /// <summary>
    /// Condition to set gender check
    /// </summary>
    public class ConditionGenderIs : MatchedConditionBase<EvaluationContext>
    {
        public ConditionGenderIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.CustomerGender))
        {
            Value = "female";
            MatchCondition = "Matching";
        }
    }
}