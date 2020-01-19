using BenchmarkDotNet2Highcharts.Helpers;
using BenchmarkDotNet2Highcharts.Models;
using BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet;
using BenchmarkDotNet2Highcharts.Models.Highcharts;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Business
{
    internal class BenchmarkMapper
    {
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
            plot.XAxis.Categories = series.First().Select(x => x.Method).ToArray();
            plot.YAxis.Title = new YAxisTitle();

            series.OnEach(x => plot.Series.AddSeries(x.Key, x));

            FitPlotUnits(plot);

            return plot;
        }

        private string GetPlotTitle(Benchmark benchmark)
        {
            var parametersBlock = benchmark.Parameters == null ?
                string.Empty :
                $": {benchmark.Parameters}";

            return $"{benchmark.Namespace}.{benchmark.Type}{parametersBlock}";
        }

        private void FitPlotUnits(Plot plot)
        {
            var bestFitUnit = UnitFitter.ApplyBestFit(plot.Series);

            plot.YAxis.Title.Unit = bestFitUnit;
        }
    }
}
