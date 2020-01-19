using BenchmarkDotNet2Highcharts.Helpers;
using BenchmarkDotNet2Highcharts.Models.BenchmarkDotNet;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkDotNet2Highcharts.Models.Highcharts.Series
{
    internal abstract class AbstractSeriesCollection
    {
        public abstract void AddSeries(string name, IEnumerable<Benchmark> benchmarks);
        public abstract decimal Min();
        public abstract void DivideValues(decimal value);
        public abstract void SetUnit(Unit value);
    }

    internal abstract class AbstractSeriesCollection<T> : AbstractSeriesCollection, IEnumerable<T>
        where T : AbstractSeries
    {
        private readonly List<T> _data = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }

        public override void AddSeries(string name, IEnumerable<Benchmark> benchmarks)
        {
            _data.Add(CreateSeries(name, benchmarks));
        }

        public override decimal Min()
        {
            return _data.Min(x => x.Min());
        }

        public override void DivideValues(decimal value)
        {
            _data.OnEach(x => x.DivideValues(value));
        }

        public override void SetUnit(Unit value)
        {
            _data.OnEach(x => x.Tooltip.Unit = value);
        }

        protected abstract T CreateSeries(string name, IEnumerable<Benchmark> benchmarks);
    }
}
