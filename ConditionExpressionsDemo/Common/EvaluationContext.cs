using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConditionExpressionsDemo.Common
{
    public class EvaluationContext : IEvaluationContext
    {

        public EvaluationContext()
        {
            Attributes = new Dictionary<string, string>();
        }

        public object ContextObject { get; set; }

        protected IDictionary<string, string> Attributes { get; set; }

        public virtual int CustomerAge { get; set; }

        public virtual string CustomerGender { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual int OrdersCount { get; set; }
    }
}