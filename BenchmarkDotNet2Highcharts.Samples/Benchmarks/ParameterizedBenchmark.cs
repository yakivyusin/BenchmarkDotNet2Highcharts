using BenchmarkDotNet.Attributes;
using System.Threading;

namespace BenchmarkDotNet2Highcharts.Samples.Benchmarks
{
    [JsonExporterAttribute.Brief]
    public class ParameterizedBenchmark
    {
        [Params(200, 300)]
        public int A { get; set; }

        [Params(20, 30, 40)]
        public int B { get; set; }

        [Benchmark]
        public void C() => Thread.Sleep(A + B);

        [Benchmark]
        public void D() => Thread.Sleep(A - B);
    }
}
