using System.Collections.Generic;
using System.Linq;

namespace Graphs.UI.Extensions
{
    public static class EnumerableExtension
    {
        public static string GetArrayStringWithMessage<T>(this IEnumerable<T> array, string message)
        {
            return array.Aggregate(message, (current, item) => current + (item + " "));
        }
    }
}