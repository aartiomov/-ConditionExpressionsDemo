using DynamicExpressionsSample.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DynamicExpressionsSample.Common
{
    public abstract class DynamicExpression : IDynamicExpression
    {
        public DynamicExpression()
        {
            Id = this.GetType().Name;
            AvailableChildren = new List<DynamicExpression>();
            Children = new List<DynamicExpression>();
        }

        #region IDynamicExpression Members

        public string Id { get; set; }

        #endregion
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.All)]
        public ICollection<DynamicExpression> AvailableChildren { get; set; }
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.All)]
        public ICollection<DynamicExpression> Children { get; set; }

        public T FindAvailableExpression<T>() where T : IDynamicExpression
        {
            var retVal = this.Traverse(x => x.AvailableChildren).SelectMany(x => x.AvailableChildren).OfType<T>().FirstOrDefault();
            return retVal;
        }
        public T FindChildrenExpression<T>() where T : IDynamicExpression
        {
            var retVal = this.Traverse(x => x.Children).SelectMany(x => x.Children).OfType<T>().FirstOrDefault();
            return retVal;
        }
    }
}