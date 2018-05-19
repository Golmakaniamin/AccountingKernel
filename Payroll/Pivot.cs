using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingKernel
{
    public static class Pivot
    {
        public static Dictionary<TKey1, Dictionary<TKey2, TValue>>
                        Pivot<TSource, TKey1, TKey2, TValue>
                        (
                            this IEnumerable<TSource> source,
                            Func<TSource, TKey1> key1Selector,
                            Func<TSource, TKey2> key2Selector,
                            Func<IEnumerable<TSource>, TValue> aggregate
                        )
        {
            return source.GroupBy(key1Selector)
                         .Select(
                            key1Group => new
                            {
                                Key = key1Group.Key,
                                Value = key1Group.GroupBy(key2Selector)
                                     .Select(
                                        key2Group => new
                                        {
                                            K = key2Group.Key,
                                            V = aggregate(key2Group)
                                        })
                                     .ToDictionary(e => e.K, o => o.V)
                            })
                         .ToDictionary(e => e.Key, o => o.Value);
        }
    }
}
