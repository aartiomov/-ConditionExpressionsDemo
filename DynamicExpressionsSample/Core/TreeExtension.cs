using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicExpressionsSample.Core
{
    /// <summary>
    /// Helper class
    /// </summary>
    public static class TreeExtension
    {
        public static IEnumerable<T> Traverse<T>(this T node, Func<T, IEnumerable<T>> childrenFor)
        {
            yield return node;

            var childNodes = childrenFor(node);
            if (childNodes != null)
            {
                foreach (var childNode in childNodes.SelectMany(n => n.Traverse(childrenFor)))
                {
                    yield return childNode;
                }
            }
        }

    }
}