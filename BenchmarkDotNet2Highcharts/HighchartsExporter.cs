using BenchmarkDotNet2Highcharts.Business;
using System;

namespace BenchmarkDotNet2Highcharts
{
    public class HighchartsExporter
    {
        private const string DefaultFolderPath = "./BenchmarkDotNet.Artifacts/results";

        private readonly BenchmarkLoader _benchmarkLoader;
        private readonly BenchmarkMapper _benchmarkMapper;

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
            _benchmarkMapper = new BenchmarkMapper();
        }

        public void Export()
        {
            var benchmarks = _benchmarkLoader.Load();

            if (benchmarks.Count == 0)
            {
                return;
            }

            foreach (var benchmark in benchmarks)
            {
                var plots = _benchmarkMapper.Map(benchmark);
            }
        }
    }
}
