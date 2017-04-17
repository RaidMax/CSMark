# CSMark
A simple CPU benchmark using the cross-platform C# .NET Core .

This application works on Windows 7 SP1 +, macOS 10.11 + and Ubuntu based Linux Distributions.

## Contributing

### Requirements for building the source code
* [DotNetCore 1.1 SDK](https://www.microsoft.com/net/core)
* Knowledge of C# and .NET Core
* Some sort of IDE (such as Visual Studio 2017) or Code Editor (such as Atom or VS Code)

### Contributions
Have a feature you'd like to add? Want to fix some issues you've experienced?

* 1. Download the SDK and development tools needed for your environment.
* 2. Fork the repository
* 3. Make any changes you'd like to make.
* 4. Debug the program using the SDK stated above. 
* 5. Submit a pull request and state what changes have been made along with what platform it was tested on.

## Benchmarks

### Requirements for running the Benchmark
* For Windows based OS: Windows 7 SP1, Windows 8.1 or Windows 10
* For Linux based OS: An Ubuntu 16.04 or Ubuntu 16.10 based distribution is required
* For Mac: OS X 10.11 or macOS 10.12 is required

Linux Distributions based on redhat linux may be supported in the future.

### Benchmarks included so far:
* Pythagoras based benchmark which involves calculating either the length of the hypotenuse, adjacent length or opposite length.
* Trigonometry based benchmark which involves calculating the size of an angle based on any 2 of: hypotenuse, adjacent or opposite sides.
* A nice Multi Threaded version of all the existing benchmarks.

### Benchmarks that I'm interested in adding
* Some kind of Logarithm based calculation
* Simulatenous Equation solving
* Differentiating with respect to X (dy/dx)
* And more stuff :)

## Notes
* Versions which are of a different major or minor version in the format of [Major].[Minor].[Patch] should not be used to compare different CPUs.
When comparing CPUs, the same exact version of the benchmark should be used across testing platforms.

Testing across versions within the same minor version may be acceptable however they may alter results. For the greatest accuracy please use the same version accross all devices you test.

## Support  
If your OS isn't stated above then it's quite likely that it's not supported.

If you'd like to see an OS supported then please [suggest an improvement](https://github.com/AluminiumTech/CSMark/issues/).

There are no plans to support Windows Vista or earlier versions of Windows.
