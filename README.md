# CSMark
A =CPU benchmark using the cross-platform C# .NET Core .
This application works on Windows, macOS and Linux Distributions.

## Installation insturctions.
[(Linux Installation Guide)](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/RunningCSMarkOnLinux.md).
[(Linux Installation Guide)](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/RunningCSMarkOnLinux.md).

## Contributing
For details on Contributing check out the [Contribution Guide](https://github.com/CSMarkBenchmark/CSMark/blob/master/CONTRIBUTING.md)

## Benchmarks

### Requirements for running the Benchmarks
DotNetCore runtime 2.0.x is required

[Download the DotNetCore runtime here](https://www.microsoft.com/net/download/core#/runtime)

__List Of Supported Platforms__
* Windows 10 (ARM, ARM64, X64) (10.0.14393 or newer required) or Windows Server 2016
* macOS 10.12 "Sierra" and 10.13 "High Sierra"
* Ubuntu 16.04 LTS, Ubuntu 17.04 or Ubuntu 17.10
* Debian 8.7 (or newer) or Debian 9
* CentOS or RedHat Linux Enterprise 7 (or newer)
* SUSE Linux Enterprise 12 SP2 +
* Fedora 26 (or newer)
* openSUSE 42.2 (or newer)
* LinuxMint 18 (or newer)

[See OS Support Document for more details](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/OS_Support.md)

### Installation Guides
* [Running CSMark On Linux](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/RunningCSMarkOnLinux.md)
* [Mac Installation Guide coming soon]

### Benchmarks included and upcoming
Check out the [Benchmarks ReadMe](https://github.com/CSMarkBenchmark/CSMarkLib/blob/master/Benchmarks.md)

## Notes
* Results from CSMark versions which are of a different major or minor version, in the format of [Major].[Minor].[Build].[Revision] , than another version should not be compared unless explicitly stated otherwise.
* When comparing CPUs, the same exact version of the benchmark should be used across testing platforms.

## FAQ
__Question:__ Why is CSMark a CLI program?
__Answer:__ To allow it to run on Windows, Mac and Linux. DotNetCore currently doesn't contain a cross-platform GUI component however if one does come in the future, an attempt to migrate to a GUI based program will be made.

__Question:__ I'm having issues running CSMark.
__Answer:__ That's not a question :P. Try checking out the [Troubleshooting Documentation](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/Troubleshooting.md).

__Question:__ Does CSMark work offline?
__Answer:__ Yes, CSMark can function complete normally when offline. Users should note that checking for updates is not available when online. Users wanting to check if a version is supported or checking documentation will require internet access.

__Question:__ Where can I hang out with the CSMark community?
__Answer:__ There's a [CSMark Discord](https://discord.gg/CMeFZbN) and a [CSMark Steam Group](http://steamcommunity.com/groups/csmark).

__Question:__ Can I (or an organization) review CSMark?
__Answer:__ Of course! We'd like to get in contact with you prior to the publishing of your review. Email or Discord DM a maintainer is preferable. I will try to respond and if I'm busy, another maintainer or contributor could respond.

__Question:__ Can I make videos or educational content around CSMark?
__Answer:__ Of course! We're happy to allow Standard Users to create educational videos and/or content around CSMark. I don't sponsor videos but I will be happy to answer any questions if you send an email or Discord DM to me.

__Question:__ Is the version of CSMark I'm using supported?
__Answer:__ You can check the status of CSMark support at the [CSMark Support Documentation](https://github.com/CSMarkBenchmark/CSMark/blob/master/Support.md).

__Question:__ Is my OS supported?
__Answer:__ If your OS isn't stated above then it's quite likely that it's not supported.
If you'd like to see an OS supported then please [suggest an improvement](https://github.com/CSMarkBenchmark/CSMark/issues/).