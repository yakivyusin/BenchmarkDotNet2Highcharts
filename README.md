# BenchmarkDotNet2Highcharts

Exporter to interactive charts (uses Highcharts) for BenchmarkDotNet. Supports simple, parameterized and cross-framework benchmarks!

## Quick start
1. Install NuGet package
```
Install-Package BenchmarkDotNet2Highcharts
```

2. Add to your benchmarks default JsonBriefExporter (library will parse output files of this exporter to build charts)
```
using BenchmarkDotNet.Attributes;

[JsonExporterAttribute.Brief]
public class Benchmark
```

3. Add to your `Main` initializing and launch of exporter, after benchmarks run
```
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
var hc = new HighchartsExporter();
hc.Export();
```

## Chart types
- Box plot
- Column plot - to be implemented
- TBA...

## Samples
- [Simple](https://yakivyusin.github.io/BenchmarkDotNet2Highcharts/SimpleBenchmark.html)
- [Parameterized](https://yakivyusin.github.io/BenchmarkDotNet2Highcharts/ParameterizedBenchmark.html)
- [Cross-framework](https://yakivyusin.github.io/BenchmarkDotNet2Highcharts/CrossPlatformBenchmark.html)
