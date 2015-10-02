using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicExpressionsSample.Common
{
    public class EvaluationContext : IEvaluationContext
    {

        public EvaluationContext()
        {
            Attributes = new Dictionary<string, string>();
        }

        public object ContextObject { get; set; }

        protected IDictionary<string, string> Attributes { get; set; }

        public virtual int ShopperAge { get; set; }

        public virtual string ShopperGender { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual int ShopperOrders { get; set; }
                
    }
}