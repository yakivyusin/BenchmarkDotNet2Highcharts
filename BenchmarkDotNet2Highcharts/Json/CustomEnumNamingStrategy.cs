using Newtonsoft.Json.Serialization;

namespace BenchmarkDotNet2Highcharts.Json
{
    internal class CustomEnumNamingStrategy : CamelCaseNamingStrategy
    {
        public override string GetPropertyName(string name, bool hasSpecifiedName)
        {
            return base.GetPropertyName(name, hasSpecifiedName).ToLower();
        }
    }
}
