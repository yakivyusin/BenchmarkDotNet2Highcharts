using System;

namespace BenchmarkDotNet2Highcharts
{
    public class HighchartsExporter
    {
        private const string DefaultFolderPath = "./BenchmarkDotNet.Artifacts/results";

        public HighchartsExporter() : this(DefaultFolderPath)
        {

        }

        public HighchartsExporter(string folderPath)
        {
            if (folderPath == null)
            {
                throw new ArgumentNullException(nameof(folderPath));
            }
        }
    }
}
