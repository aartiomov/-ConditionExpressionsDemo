using System;

namespace DynamicExpressionsSample.Common
{
    public interface IConditionExpression
    {
        System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetConditionExpression();

    }
}
