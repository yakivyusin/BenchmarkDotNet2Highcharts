using BenchmarkDotNet.Attributes;
using System.Threading;

namespace BenchmarkDotNet2Highcharts.Samples.Benchmarks
{
    [JsonExporterAttribute.Brief]
    public class SimpleBenchmark
    {
        [Benchmark]
        public void A() => Thread.Sleep(1200);

        [Benchmark]
        public void B() => Thread.Sleep(1500);
    }
}
