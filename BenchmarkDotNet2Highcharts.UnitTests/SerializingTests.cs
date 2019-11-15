using BenchmarkDotNet2Highcharts.Json;
using BenchmarkDotNet2Highcharts.UnitTests.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BenchmarkDotNet2Highcharts.UnitTests
{
    [TestFixture]
    public class SerializingTests
    {
        private readonly SerializingSettings serializingSettings = new SerializingSettings();

        [Test]
        public void PropertyNamesAsCamelCase()
        {
            var obj = new
            {
                Property = 1,
                PropertyTwo = 2
            };

            var json = JsonConvert.SerializeObject(obj, serializingSettings)
                .RemoveWhitespaces();

            Assert.AreEqual(@"{""property"":1,""propertyTwo"":2}", json);
        }

        [Test]
        public void EnumValuesAsLowerCase()
        {
            var obj = new
            {
                A = LowerCaseEnum.Value,
                B = LowerCaseEnum.ValueTwo,
                C = LowerCaseEnum.VT
            };

            var json = JsonConvert.SerializeObject(obj, serializingSettings)
                .RemoveWhitespaces();

            Assert.AreEqual(@"{""a"":""value"",""b"":""valuetwo"",""c"":""vt""}", json);
        }

        private enum LowerCaseEnum
        {
            Value,
            ValueTwo,
            VT
        }
    }
}
