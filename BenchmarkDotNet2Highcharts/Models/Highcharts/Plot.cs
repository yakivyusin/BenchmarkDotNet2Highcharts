using BenchmarkDotNet2Highcharts.Models.Highcharts.Series;

namespace BenchmarkDotNet2Highcharts.Models.Highcharts
{
    internal class Plot
    {
        public Chart Chart { get; set; }
        public Title Title { get; set; }
        public Legend Legend { get; set; }
        public XAxis XAxis { get; set; }
        public YAxis YAxis { get; set; }
        public AbstractSeriesCollection Series { get; set; }
    }
}
