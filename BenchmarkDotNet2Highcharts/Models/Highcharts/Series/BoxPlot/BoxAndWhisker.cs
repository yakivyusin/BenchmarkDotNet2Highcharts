using BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet;
using System.Collections;
using System.Collections.Generic;

namespace BenchmarkDotNet2Highcharts.Models.Highcharts.Series.BoxPlot
{
    internal class BoxAndWhisker : IEnumerable<decimal>
    {
        public decimal Min { get; set; }
        public decimal Q1 { get; set; }
        public decimal Median { get; set; }
        public decimal Q3 { get; set; }
        public decimal Max { get; set; }

        public BoxAndWhisker(Benchmark benchmark)
        {
            Min = benchmark.Statistics.Min;
            Q1 = benchmark.Statistics.Q1;
            Median = benchmark.Statistics.Median;
            Q3 = benchmark.Statistics.Q3;
            Max = benchmark.Statistics.Max;
        }

        public IEnumerator<decimal> GetEnumerator()
        {
            yield return Min;
            yield return Q1;
            yield return Median;
            yield return Q3;
            yield return Max;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<decimal>)this).GetEnumerator();
        }
    }
}
