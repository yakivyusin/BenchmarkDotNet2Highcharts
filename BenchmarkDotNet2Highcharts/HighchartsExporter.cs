using BenchmarkDotNet2Highcharts.Business;
using System;

namespace BenchmarkDotNet2Highcharts
{
    public class HighchartsExporter
    {
        private const string DefaultFolderPath = "./BenchmarkDotNet.Artifacts/results";
        private readonly BenchmarkLoader _benchmarkLoader;

        public HighchartsExporter() : this(DefaultFolderPath)
        {

        }

        public HighchartsExporter(string folderPath)
        {
            if (folderPath == null)
            {
                throw new ArgumentNullException(nameof(folderPath));
            }

            _benchmarkLoader = new BenchmarkLoader(folderPath);
        }

        public void Export()
        {
            var benchmarks = _benchmarkLoader.Load();

            if (benchmarks.Count == 0)
            {
                return;
            }
        }
    }
}
