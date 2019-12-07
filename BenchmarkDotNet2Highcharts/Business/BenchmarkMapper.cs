using BenchmarkDotNet2Highcharts.Models;
using BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet;
using BenchmarkDotNet2Highcharts.Models.Highcharts;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Business
{
    internal class BenchmarkMapper
    {
        private const string DefaultSeriesTooltip = "<b>Observations {point.key} (ns)</b><br/>";
        private const string DefaltYAxisLabel = "Values (ns)";

        private readonly PlotFactory _plotFactory = new PlotFactory();

        public List<Plot> Map(BriefJsonFile benchmark)
        {
            var plots = benchmark.Benchmarks.GroupBy(x => x.Parameters);

            return plots
                .Select(x => Map(x))
                .ToList();
        }

        private Plot Map(IEnumerable<Benchmark> benchmarkGroup)
        {
            var plot = _plotFactory.CreateBoxPlot(GetPlotTitle(benchmarkGroup.First()));
            var series = benchmarkGroup.GroupBy(x => x.SpecificRuntime);

            plot.Legend.Enabled = series.Count() > 1;
            plot.Series = series.Select(x => MapToSeries(x.Key, x)).ToArray();
            plot.XAxis.Categories = series.First().Select(x => x.Method).ToArray();
            plot.YAxis.Title = new Title
            {
                Text = DefaltYAxisLabel
            };

            return plot;
        }

        private Series MapToSeries(string runtime, IEnumerable<Benchmark> benchmarkSeries)
        {
            var series = new Series
            {
                Name = runtime,
                Data = benchmarkSeries
                    .Select(x => new[]
                    {
                        x.Statistics.Min,
                        x.Statistics.Q1,
                        x.Statistics.Median,
                        x.Statistics.Q3,
                        x.Statistics.Max
                    })
                    .ToArray(),
                Tooltip = new Tooltip
                {
                    HeaderFormat = DefaultSeriesTooltip
                }
            };

            return series;
        }

        private string GetPlotTitle(Benchmark benchmark)
        {
            var parametersBlock = benchmark.Parameters == null ?
                string.Empty :
                $": {benchmark.Parameters}";

            return $"{benchmark.Namespace}.{benchmark.Type}{parametersBlock}";
        }
    }
}
