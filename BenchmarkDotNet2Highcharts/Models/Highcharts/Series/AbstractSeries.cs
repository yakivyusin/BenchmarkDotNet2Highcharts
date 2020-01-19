namespace BenchmarkDotNet2Highcharts.Models.Highcharts.Series
{
    internal abstract class AbstractSeries
    {
        public string Name { get; set; }
        public Tooltip Tooltip { get; set; }

        public abstract decimal Min();
        public abstract void DivideValues(decimal value);
    }
}
