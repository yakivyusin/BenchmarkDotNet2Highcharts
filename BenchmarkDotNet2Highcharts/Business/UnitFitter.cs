using BenchmarkDotNet2Highcharts.Models;
using BenchmarkDotNet2Highcharts.Models.Highcharts.Series;

namespace BenchmarkDotNet2Highcharts.Business
{
    internal static class UnitFitter
    {
        public static Unit ApplyBestFit(AbstractSeriesCollection values)
        {
            var minValue = values.Min();
            var currentUnit = Unit.Nanosecond;

            while (minValue >= ConvertUnitToNanoseconds(currentUnit) * 1000 && currentUnit <= Unit.Second)
            {
                currentUnit++;
            }

            if (currentUnit != Unit.Nanosecond)
            {
                var divideCoeff = ConvertUnitToNanoseconds(currentUnit);

                values.DivideValues(divideCoeff);
                values.SetUnit(currentUnit);
            }

            return currentUnit;
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
