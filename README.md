# CSMark
A simple CPU benchmark using the cross-platform C# .NET Core .

This application works on Windows 7 SP1 +, macOS 10.11 + and Linux Distributions.

## Contributing
For details on Contributing check out the [Contribution Guide](https://github.com/AluminiumTech/CSMark/blob/master/CONTRIBUTING.md)

## Benchmarks

### Requirements for running the Benchmarks
* CSMark 0.13.0 or Prior: DotNetCore runtime 1.1 is required
* CSMark 0.14.0 or newer: DotNetCore runtime 2.0 is required

[Download the DotNetCore runtime here](https://www.microsoft.com/net/download/core#/runtime)

The table below should give you a rough idea of CSMark OS Support.

![Image of CSMark Platforms Supported](https://github.com/AluminiumTech/CSMark/blob/master/assets/platformSupport.PNG)

Notes: ARM64 and ARM32 are supported by CSMark as of CSMark 0.14.0

### Benchmarks included and upcoming
Check out the [Benchmarks ReadMe](https://github.com/AluminiumTech/CSMark/blob/master/Benchmark_ReadMe.md)

### How do I know what accuracy level to choose?
Check out the [Accuracy Levels Guide](https://github.com/AluminiumTech/CSMark/blob/master/AccuracyLevels.md).

## Notes
* Results from CSMark versions which are of a different major or minor version, in the format of [Major].[Minor].[Patch], than another version should not be compared unless explicitly stated otherwise.
* When comparing CPUs, the same exact version of the benchmark should be used across testing platforms.

## Support  
If your OS isn't stated above then it's quite likely that it's not supported.
If you'd like to see an OS supported then please [suggest an improvement](https://github.com/AluminiumTech/CSMark/issues/).

There are no plans to support Windows Vista or earlier versions of Windows.

### Known Issues
Dotnetcore runtime for dotnetcore 1.1 does not currently support linux distributions or versions not specified. Users of unsupported linux distributions will need to wait until the upgrade to dotnetcore 2.0 which will contain a default linux build option.
