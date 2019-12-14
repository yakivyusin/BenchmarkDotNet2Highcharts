using BenchmarkDotNet2Highcharts.Helpers;
using BenchmarkDotNet2Highcharts.Resources;

namespace BenchmarkDotNet2Highcharts.Models.Highcharts
{
    internal class YAxisTitle
    {
        public Unit Unit { get; set; }

        public string Text => string.Format(
            Resource.DefaultYAxisLabel,
            Unit.GetTranslation());
    }
}
