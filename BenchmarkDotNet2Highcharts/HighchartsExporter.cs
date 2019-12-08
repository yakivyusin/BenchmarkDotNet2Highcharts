using BenchmarkDotNet2Highcharts.Business;
using BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet;
using System;
using System.IO;

namespace BenchmarkDotNet2Highcharts
{
    public class HighchartsExporter
    {
        private const string DefaultFolderPath = "./BenchmarkDotNet.Artifacts/results";

        private readonly BenchmarkLoader _benchmarkLoader;
        private readonly BenchmarkMapper _benchmarkMapper;
        private readonly HighchartFileBuilder _highchartFileBuilder;
        private readonly string _folderPath;

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
            _highchartFileBuilder = new HighchartFileBuilder();
            _folderPath = folderPath;
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
                var fileContent = _highchartFileBuilder.Build(plots);
                var fileName = GetPlotFileName(benchmark);
                var filePath = Path.Combine(_folderPath, fileName);

                File.WriteAllText(filePath, fileContent);
            }
        }

        private string GetPlotFileName(BriefJsonFile jsonFile)
        {
            var benchmark = jsonFile.Benchmarks[0];

            return $"{benchmark.Namespace}.{benchmark.Type}-highcharts.html";
        }
    }
}
