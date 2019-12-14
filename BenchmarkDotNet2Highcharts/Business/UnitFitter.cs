using BenchmarkDotNet2Highcharts.Models;
using BenchmarkDotNet2Highcharts.Models.Highcharts;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Business
{
    internal static class UnitFitter
    {
        public static Unit ApplyBestFit(Series[] values)
        {
            var minValue = values.Min(s => s.Data.Min(x => x.Min()));
            var currentUnit = Unit.Nanosecond;

            while (minValue >= ConvertUnitToNanoseconds(currentUnit) * 1000 && currentUnit <= Unit.Second)
            {
                currentUnit++;
            }

            if (currentUnit != Unit.Nanosecond)
            {
                var divideCoeff = ConvertUnitToNanoseconds(currentUnit);

                foreach (var series in values)
                {
                    ApplyBestFitToSeries(series, divideCoeff);
                }
            }

            return currentUnit;
        }

        private static void ApplyBestFitToSeries(Series series, decimal divideCoeff)
        {
            for (int i = 0; i < series.Data.Length; i++)
            {
                for (int j = 0; j < series.Data[i].Length; j++)
                {
                    series.Data[i][j] /= divideCoeff;
                }
            }
        }

        private static decimal ConvertUnitToNanoseconds(Unit unit)
        {
            decimal value = 1;

            for (int i = 0; i < (int)unit; i++)
            {
                value *= 1000;
            }

            return value;
        }
    }
}
