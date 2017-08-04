# CSMark
A simple CPU benchmark using the cross-platform C# .NET Core .

This application works on Windows 7 SP1 +, macOS 10.11 + and Linux Distributions.

## Contributing

### Requirements for building the source code
* [DotNetCore 1.1 SDK](https://www.microsoft.com/net/download/core#/sdk)
* An IDE (such as Visual Studio 2017) or a Code Editor (such as Atom or VS Code)

### Contributions
Want to contribute to CSMark?
* 1. Download the SDK and development tools needed for your environment.
* 2. Fork the repository
* 3. Make changes
* 4. Debug the program
* 5. Ensure the changes you made does not cause the program to crash
* 6. Submit a pull request and state what changes have been made along with what platform it was tested on.

## Benchmarks

### Requirements for running the Benchmark
* All Platforms: [Download the current DotNetCore runtime](https://www.microsoft.com/net/download/core#/runtime)
* For Windows based OS: Windows 7 SP1, Windows 8.1 or Windows 10.
* For Linux based OS: [See releases page](https://github.com/AluminimTech/CSMark/releases).
* For Mac: OS X 10.11 is required.

### Benchmarks included so far:
* Pythagoras based benchmark which involves calculating either the length of the hypotenuse, adjacent length or opposite length.
* Trigonometry based benchmark which involves calculating the size of an angle based on any 2 of: hypotenuse, adjacent or opposite sides.
* Percentage Error based benchmark which involves calculating the percentage difference between 2 given numbers.
* A Multi Threaded version of all the above benchmarks.

### Benchmarks that I'm interested in adding
* Some kind of Logarithm based calculation
* Simultaneous Equation solving
* Differentiating with respect to X (dy/dx)
* And more stuff :)

## Notes
* Results from CSMark versions which are of a different major or minor version, in the format of [Major].[Minor].[Patch], than another version should not be compared unless explicitly stated otherwise.
* When comparing CPUs, the same exact version of the benchmark should be used across testing platforms.

## Support  
If your OS isn't stated above then it's quite likely that it's not supported.
If you'd like to see an OS supported then please [suggest an improvement](https://github.com/AluminiumTech/CSMark/issues/).

There are no plans to support Windows Vista or earlier versions of Windows.

### Known Issues
Dotnetcore runtime for dotnetcore 1.1 does not currently support linux distributions or versions not specified. Users of unsupported linux distributions will need to wait until the upgrade to dotnetcore 2.0 which will contain a default linux build option.
