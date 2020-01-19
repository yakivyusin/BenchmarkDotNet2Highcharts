using BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Models.Highcharts.Series.BoxPlot
{
    internal class BoxPlotSeriesCollection : AbstractSeriesCollection<BoxPlotSeries>
    {
        protected override BoxPlotSeries CreateSeries(string name, IEnumerable<Benchmark> benchmarks)
        {
            return new BoxPlotSeries
            {
                Name = name,
                Data = benchmarks
                    .Select(x => new BoxAndWhisker(x))
                    .ToArray(),
                Tooltip = new Tooltip()
            };
        }
    }
}
