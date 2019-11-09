namespace BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet
{
    internal class BenchmarkStatistics
    {
        public decimal Min { get; set; }
        public decimal Q1 { get; set; }
        public decimal Median { get; set; }
        public decimal Q3 { get; set; }
        public decimal Max { get; set; }
    }
}
