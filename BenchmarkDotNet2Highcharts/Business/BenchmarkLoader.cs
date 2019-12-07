using BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Business
{
    internal class BenchmarkLoader
    {
        private const string BenchmarkMask = "*-report-brief.json";
        private readonly string _folderPath;

        public BenchmarkLoader(string folderPath)
        {
            _folderPath = folderPath;
        }

        public List<BriefJsonFile> Load()
        {
            var files = Directory.GetFiles(_folderPath, BenchmarkMask, SearchOption.TopDirectoryOnly);

            return files
                .Select(x => LoadFile(x))
                .Where(x => x != null)
                .ToList();
        }

        private BriefJsonFile LoadFile(string file)
        {
            var fileContent = File.ReadAllText(file);

            try
            {
                return JsonConvert.DeserializeObject<BriefJsonFile>(fileContent);
            }
            catch
            {
                return null;
            }
        }
    }
}
