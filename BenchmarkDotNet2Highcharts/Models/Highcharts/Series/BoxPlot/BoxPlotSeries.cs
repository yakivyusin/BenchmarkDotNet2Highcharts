using BenchmarkDotNet2Highcharts.Helpers;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Models.Highcharts.Series.BoxPlot
{
    internal class BoxPlotSeries : AbstractSeries
    {
        public BoxAndWhisker[] Data { get; set; }

        public override decimal Min()
        {
            return Data.Min(x => x.Min());
        }

        public override void DivideValues(decimal value)
        {
            Data.OnEach(x =>
            {
                x.Min /= value;
                x.Q1 /= value;
                x.Median /= value;
                x.Q3 /= value;
                x.Max /= value;
            });
        }
    }
}
