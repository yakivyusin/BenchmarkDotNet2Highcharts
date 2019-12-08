using BenchmarkDotNet2Highcharts.Json;
using BenchmarkDotNet2Highcharts.Models.Highcharts;
using BenchmarkDotNet2Highcharts.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Business
{
    internal class HighchartFileBuilder
    {
        public string Build(IEnumerable<Plot> plots)
        {
            var fileTemplate = Resource.HighchartFileTemplate;

            fileTemplate = fileTemplate.Replace(@"<!-- PlotSection -->", GetPlotBoxes(plots.Count()));
            fileTemplate = fileTemplate.Replace(@"<!-- ScriptSection -->", GetPlotScripts(plots));

            return fileTemplate;
        }

        private string GetPlotBoxes(int count)
        {
            var boxTemplates = Enumerable.Range(0, count)
                .Select(i => string.Format(Resource.PlotBoxTemplate, i.ToString()))
                .ToArray();

            return string.Join(Environment.NewLine, boxTemplates);
        }

        private string GetPlotScripts(IEnumerable<Plot> plots)
        {
            var scriptTemplates = Enumerable.Range(0, plots.Count())
                .Select(i => string.Format(
                    Resource.PlotInitTemplate,
                    i.ToString(),
                    JsonConvert.SerializeObject(plots.ElementAt(i), new SerializingSettings())))
                .ToArray();

            return string.Join(Environment.NewLine, scriptTemplates);
        }
    }
}
