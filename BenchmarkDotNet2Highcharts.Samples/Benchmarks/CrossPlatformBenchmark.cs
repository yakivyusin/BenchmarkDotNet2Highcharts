using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Threading;

namespace BenchmarkDotNet2Highcharts.Samples.Benchmarks
{
    [JsonExporterAttribute.Brief]
    [SimpleJob(RuntimeMoniker.NetCoreApp22)]
    [SimpleJob(RuntimeMoniker.Net472)]
    public class CrossPlatformBenchmark
    {
        [Params(20, 30)]
        public int A { get; set; }

        [Benchmark]
        public void B() => Thread.Sleep(500 + A);

        [Benchmark]
        public void C() => Thread.Sleep(700 + A);
    }
}
