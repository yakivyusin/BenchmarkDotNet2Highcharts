using BenchmarkDotNet2Highcharts.Models;
using BenchmarkDotNet2Highcharts.Resources;

namespace BenchmarkDotNet2Highcharts.Helpers
{
    internal static class UnitExtensions
    {
        public static string GetTranslation(this Unit unit)
        {
            var unitName = unit.ToString("G");

            return Resource.ResourceManager.GetString($"Unit_{unitName}");
        }
    }
}
