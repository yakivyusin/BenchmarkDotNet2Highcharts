﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet
{
    internal class Benchmark
    {
        public string DisplayInfo { get; set; }
        public string Namespace { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        public string Parameters { get; set; }
        public BenchmarkStatistics Statistics { get; set; }

        public Dictionary<string, string> ParameterValues => Parameters?.Split('&')
            .Select(p => p.Split('='))
            .ToDictionary(p => p[0], p => p[1]);

        public string SpecificRuntime => ParseDisplayInfoForRuntime();

        private string ParseDisplayInfoForRuntime()
        {
            var match = Regex.Match(DisplayInfo, @"\(Runtime=(?<runtime>.*)\)");

            return match.Success ?
                match.Groups["runtime"].Value :
                null;
        }
    }
}
