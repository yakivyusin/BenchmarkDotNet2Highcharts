namespace BenchmarkDotNet2Highcharts.Models.Highcharts
{
    internal class Series
    {
        public string Name { get; set; }
        public decimal[][] Data { get; set; }
        public Tooltip Tooltip { get; set; }
    }
}
