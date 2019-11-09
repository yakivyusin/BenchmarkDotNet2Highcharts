using System.Collections.Generic;

namespace BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet
{
    internal class BriefJsonFile
    {
        public EnvironmentInfo HostEnvironmentInfo { get; set; }
        public List<Benchmark> Benchmarks { get; set; }
    }
}
