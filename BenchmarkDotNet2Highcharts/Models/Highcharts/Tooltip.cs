using BenchmarkDotNet2Highcharts.Helpers;
using BenchmarkDotNet2Highcharts.Resources;

namespace BenchmarkDotNet2Highcharts.Models.Highcharts
{
    internal class Tooltip
    {
        public Unit Unit { get; set; }

        public string HeaderFormat => string.Format(
            Resource.DefaultSeriesTooltip,
            Unit.GetTranslation());
    }
}
