using BenchmarkDotNet2Highcharts.Models;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Business
{
    internal static class UnitFitter
    {
        public static Unit ApplyBestFit(decimal[][] values)
        {
            var minValue = values.Min(x => x.Min());
            var currentUnit = Unit.Nanosecond;

            while (minValue >= ConvertUnitToNanoseconds(currentUnit) * 1000 && currentUnit <= Unit.Second)
            {
                currentUnit++;
            }

            if (currentUnit != Unit.Nanosecond)
            {
                var divideCoeff = ConvertUnitToNanoseconds(currentUnit);

                for (int i = 0; i < values.Length; i++)
                {
                    for (int j = 0; j < values[i].Length; j++)
                    {
                        values[i][j] /= divideCoeff;
                    }
                }
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
