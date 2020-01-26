using BenchmarkDotNet.Running;

namespace BenchmarkDotNet2Highcharts.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            var hc = new HighchartsExporter();
            hc.Export();
        }
    }
}
