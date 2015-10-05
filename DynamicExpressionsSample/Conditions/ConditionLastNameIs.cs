using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Core;

namespace ConditionExpressionsDemo.Conditions
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