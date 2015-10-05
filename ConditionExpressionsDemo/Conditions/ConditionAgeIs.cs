

using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Core;

namespace ConditionExpressionsDemo.Conditions
{
    /// <summary>
    /// Condition to set age check
    /// </summary>
    public class ConditionAgeIs : CompareConditionBase<EvaluationContext>
    {
        public ConditionAgeIs()
            : base(ReflectionUtility.GetPropertyName<EvaluationContext>(x => x.CustomerAge))
        {
            Value = "25";
        }
    }
}