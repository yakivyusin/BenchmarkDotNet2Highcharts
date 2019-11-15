using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace BenchmarkDotNet2Highcharts.Json
{
    internal class SerializingSettings : JsonSerializerSettings
    {
        public SerializingSettings()
        {
            Formatting = Formatting.Indented;
            NullValueHandling = NullValueHandling.Ignore;
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter(new CustomEnumNamingStrategy(), false)
            };
        }
    }
}
