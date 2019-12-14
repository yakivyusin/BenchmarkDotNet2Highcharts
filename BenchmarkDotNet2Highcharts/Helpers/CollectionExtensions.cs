using System;
using System.Collections.Generic;

namespace BenchmarkDotNet2Highcharts.Helpers
{
    internal static class CollectionExtensions
    {
        public static void OnEach<T>(IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
