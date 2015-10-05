using System;

namespace ConditionExpressionsDemo.Common
{
    public interface IConditionExpression
    {
        System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetConditionExpression();

    }
}
