using BenchmarkDotNet2Highcharts.Business;
using BenchmarkDotNet2Highcharts.Models;
using NUnit.Framework;

namespace BenchmarkDotNet2Highcharts.UnitTests
{
    [TestFixture]
    public class UnitFitterTests
    {
        [Test]
        public void NanosecondsIfOneLess1000()
        {
            var data = new decimal[2][]
            {
                new [] { 500m, 1500m },
                new [] { 1600m, 2000m }
            };

            var unit = UnitFitter.ApplyBestFit(data);

            Assert.AreEqual(Unit.Nanosecond, unit);

            Assert.AreEqual(new[] { 500m, 1500m }, data[0]);
            Assert.AreEqual(new[] { 1600m, 2000m }, data[1]);
        }

        [Test]
        public void MicrosecondsIfAllEqualOrGreater1000()
        {
            var data = new decimal[2][]
            {
                new [] { 1000m, 1500m },
                new [] { 1001m, 2000m }
            };

            var unit = UnitFitter.ApplyBestFit(data);

            Assert.AreEqual(Unit.Microsecond, unit);

            Assert.AreEqual(new[] { 1m, 1.5m }, data[0]);
            Assert.AreEqual(new[] { 1.001m, 2m }, data[1]);
        }

        [Test]
        public void MicrosecondsIfOneLess1_000_000()
        {
            var data = new decimal[2][]
            {
                new [] { 1_500_000m, 1_500_000m },
                new [] { 600_000m, 2_000_000m }
            };

            var unit = UnitFitter.ApplyBestFit(data);

            Assert.AreEqual(Unit.Microsecond, unit);

            Assert.AreEqual(new[] { 1500m, 1500m }, data[0]);
            Assert.AreEqual(new[] { 600m, 2000m }, data[1]);
        }

        [Test]
        public void MillisecondsIfAllEqualOrGreater1_000_000()
        {
            var data = new decimal[2][]
            {
                new [] { 1_500_000m, 3_050_000m },
                new [] { 2_000_000m, 1_000_000m }
            };

            var unit = UnitFitter.ApplyBestFit(data);

            Assert.AreEqual(Unit.Millisecond, unit);

            Assert.AreEqual(new[] { 1.5m, 3.05m }, data[0]);
            Assert.AreEqual(new[] { 2m, 1m }, data[1]);
        }

        [Test]
        public void MillisecondsIfOneLess1_000_000_000()
        {
            var data = new decimal[2][]
            {
                new [] { 1_000_500_000m, 3_000_050_000m },
                new [] { 2_000_000_000m, 1_000_000m }
            };

            var unit = UnitFitter.ApplyBestFit(data);

            Assert.AreEqual(Unit.Millisecond, unit);

            Assert.AreEqual(new[] { 1000.5m, 3000.05m }, data[0]);
            Assert.AreEqual(new[] { 2000m, 1m }, data[1]);
        }

        [Test]
        public void SecondsIfAllEqualOrGreater1_000_000_000()
        {
            var data = new decimal[2][]
            {
                new [] { 2_000_700_000m, 3_500_000_000m },
                new [] { 1_000_000_000m, 9_000_000_000m }
            };

            var unit = UnitFitter.ApplyBestFit(data);

            Assert.AreEqual(Unit.Second, unit);

            Assert.AreEqual(new[] { 2.0007m, 3.5m }, data[0]);
            Assert.AreEqual(new[] { 1m, 9m }, data[1]);
        }
    }
}
