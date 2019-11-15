using System;

namespace BenchmarkDotNet2Highcharts.UnitTests.Helpers
{
    public static class StringExtensions
    {
        public static string RemoveWhitespaces(this string text)
        {
            return text
                .Replace("\t", string.Empty)
                .Replace(Environment.NewLine, string.Empty)
                .Replace(" ", string.Empty);
        }
    }
}
