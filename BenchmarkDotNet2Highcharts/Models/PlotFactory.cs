using BenchmarkDotNet2Highcharts.Models.Highcharts;
using BenchmarkDotNet2Highcharts.Models.Highcharts.Series.BoxPlot;

namespace BenchmarkDotNet2Highcharts.Models
{
    internal class PlotFactory
    {
        public Plot CreateBoxPlot(string title)
        {
            return new Plot
            {
                Chart = new Chart
                {
                    Type = ChartType.BoxPlot,
                    ZoomType = ZoomType.XY
                },
                Title = new Title
                {
                    Text = title
                },
                Legend = new Legend(),
                XAxis = new XAxis(),
                YAxis = new YAxis(),
                Series = new BoxPlotSeriesCollection()
            };
        }
    }
}
