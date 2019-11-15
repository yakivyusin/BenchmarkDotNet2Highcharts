using Newtonsoft.Json;

namespace BenchmarkDotNet2Highcharts.Json
{
    internal class DeserializingSettings : JsonSerializerSettings
    {
        public DeserializingSettings()
        {
            FloatParseHandling = FloatParseHandling.Decimal;
            NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
