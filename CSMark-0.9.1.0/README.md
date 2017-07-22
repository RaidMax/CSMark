# CSMark
A simple CPU benchmark using the cross-platform C# .NET Core .

This application works on Windows 7 SP1 +, macOS 10.11 + and Linux Distributions.

## Contributing

### Requirements for building the source code
* [DotNetCore 1.1 SDK](https://www.microsoft.com/net/download/core#/sdk)
* Knowledge of C# and .NET Core
* Some sort of IDE (such as Visual Studio 2017) or Code Editor (such as Atom or VS Code)

### Contributions
Want to contribute to CSMark?
* 1. Download the SDK and development tools needed for your environment.
* 2. Fork the repository
* 3. Make any changes you'd like to make.
* 4. Debug the program using the SDK stated above. 
* 5. Submit a pull request and state what changes have been made along with what platform it was tested on.

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
* Calculating Pi
* And more stuff :)

## Notes
* Scores/Results gotten from versions which are of a different major or minor version in the format of [Major].[Minor].[Patch] than another version should not be compared unless explicitly stated otherwise
* When comparing CPUs, the same exact version of the benchmark should be used across testing platforms.

## Support  
If your OS isn't stated above then it's quite likely that it's not supported.
If you'd like to see an OS supported then please [suggest an improvement](https://github.com/AluminiumTech/CSMark/issues/).

Want to make CSMark great? [Fill out this survey](https://docs.google.com/forms/d/e/1FAIpQLScUhdHnnrEVPFNgq_xG4gvVsNty7h7StNu80VaQhCByvUFeRQ/viewform?usp=sf_link)

There are no plans to support Windows Vista or earlier versions of Windows.

## Some Benchmark Results
This shows off a list of CPUs, OS used and benchmark scores.

**All results are in milliseconds. Lower numbers are better.**

Testing conducted using Official Releases of OS and minimal background applications open.
If you'd like to submit your own results, ensure you're only running a supported OS and the CSMark version specified. Laptops & Tablets should be plugged in to their respective charger and charging to run the tests. To submit results, please open a github issue along with a screenshot of CSMark running with task manager (windows) or activity monitor (mac & linux) open.

The results below have been updated for CSMark 0.7.0.0

| CPU | Cores/Threads | Base/Boost Clockspeed | TDP | OS | Pythagoras Single/Multi | Trigonometry Single/Multi | Percentage Error Single/Multi |
|---------------------|-------|-----------------------------------|-------|-------------------------|-------------------------|-------------------|-----------|
| Intel Core i5-4570 | 4C/4T | 3.2GHz/ 3.6GHz  | 84w |  Windows 10 Build 15063 | 21794ms/ 4522ms | 34809ms/ 5324ms | 12858ms/ 3019ms |
| Intel Core i7-6650U | 2C/4T | 2.2GHz/ 3.2GHz  | 15w |  Windows 10 Build 15063 | 241014ms/ 4522ms | 34506ms/ 8098ms | 12618ms/ 4372ms |
| Intel Core 2 Duo Penryn T9500 (Late 2008 17" MBP) | 2C/2T | 2.6GHz | 35w |  macOS 10.11.6| 38477ms/ 17008ms | 89275ms/ 27713ms | 22736ms/ 10853ms |