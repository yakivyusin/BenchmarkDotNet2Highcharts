using BenchmarkDotNet2Highcharts.Json;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BenchmarkDotNet2Highcharts.UnitTests
{
    [TestFixture]
    public class DeserializingTests
    {
        private readonly DeserializingSettings deserializingSettings = new DeserializingSettings();

        [Test]
        public void FloatingPointAsDecimal()
        {
            var json = @"{""Property"":3.1415}";

            var obj = JsonConvert.DeserializeObject<DecimalClass>(json, deserializingSettings);

            Assert.AreEqual(3.1415m, obj.Property);
        }

        private class DecimalClass
        {
            public decimal Property { get; set; }
        }
    }
}
