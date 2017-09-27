# CSMark
A simple CPU benchmark using the cross-platform C# .NET Core .
This application works on Windows, macOS and Linux Distributions [(See Linux Installation Guide for more details)](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/RunningCSMarkOnLinux.md).

## Contributing
For details on Contributing check out the [Contribution Guide](https://github.com/CSMarkBenchmark/CSMark/blob/master/CONTRIBUTING.md)

## Benchmarks

### Requirements for running the Benchmarks
DotNetCore runtime 2.0.0 is required

[Download the DotNetCore runtime here](https://www.microsoft.com/net/download/core#/runtime)

__List Of Supported Platforms__
* Windows 7 SP1 64 Bit or Windows Server 2008 R2 SP1 with the latest updates.
* Windows 8.1 64 Bit with Update [2919355](https://support.microsoft.com/en-us/help/2919355/windows-rt-8-1--windows-8-1--and-windows-server-2012-r2-update-april-2) or Windows Server 2012 R2 with Update [2919355](https://support.microsoft.com/en-us/help/2919355/windows-rt-8-1--windows-8-1--and-windows-server-2012-r2-update-april-2)
* Windows 10 64 Bit (Build 14393 or newer required) or Windows Server 2016
* Windows 10 ARM 32 Bit (Build 14393 or newer required)
* Windows 10 ARM 64 Bit (Build 14393 or newer required)
* macOS 10.12 "Sierra"
* macOS 10.13 "High Sierra"
* Ubuntu 16.04 LTS or Ubuntu 17.04
* Debian 8.7 (or newer) or Debian 9
* CentOS or RedHat Linux Enterprise 7 (or newer)
* SUSE Linux Enterprise 12 SP2 +
* Fedora 26 (or newer)
* openSUSE 42.2 (or newer)
* LinuxMint 18 (or newer)

[See OS Support Document for more details](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/OS_Support.md)

### Installation Guides
* [Running CSMark On Linux](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/RunningCSMarkOnLinux.md)

### Benchmarks included and upcoming
Check out the [Benchmarks ReadMe](https://github.com/CSMarkBenchmark/CSMarkLib/blob/master/Benchmarks.md)

### How do I know what accuracy level to choose?
Check out the [Accuracy Levels Documentation](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/AccuracyLevels.md).

## Notes
* Results from CSMark versions which are of a different major or minor version, in the format of [Major].[Minor].[Build].[Revision] , than another version should not be compared unless explicitly stated otherwise.
* When comparing CPUs, the same exact version of the benchmark should be used across testing platforms.

## FAQ
__Question:__ Why is CSMark a CLI program?
__Answer:__ To allow it to run on Windows, Mac and Linux. DotNetCore currently doesn't contain a cross-platform GUI component however if one does come in the future, an attempt to migrate to a GUI based program will be attempted.

__Question:__ I'm having issues running CSMark.
__Answer:__ That's not a question :P. Try checking out the [Troubleshooting Documentation](https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/Troubleshooting.md).

__Question:__ What's up with the accuracy levels?
__Answer:__ Most people can comfortably use the "Auto" accuracy. Users requiring higher accuracy can choose "Auto_Extreme".

__Question:__ Does CSMark work offline?
__Answer:__ Yes, CSMark can function complete normally when offline. Users should note that checking for updates is not available when online. Users wanting to check if a version is supported or checking documentation will require internet access.

__Question:__ Where can I hang out with the CSMark community?
__Answer:__ There's a [CSMark Discord](https://discord.gg/CMeFZbN) and a [CSMark Steam Group](http://steamcommunity.com/groups/csmark).

__Question:__ Can I (or an organization) review CSMark?
__Answer:__ Of course! We'd like to get in contact with you prior to the publishing of your review. Email or Discord DM a maintainer is preferable. I will try to respond and if I'm busy, another maintainer or contributor could respond.

__Question:__ Can I make videos or educational content around CSMark?
__Answer:__ Of course! We're happy to allow Standard Users to create educational videos and/or content around CSMark. I don't sponsor videos but I will be happy to answer any questions if you send an email or Discord DM to me.

__Question:__ What support am I eligible for?
__Answer:__ All users are eligible for Community Support. Community Support usually consists of receiving support from the Community and possibly maintainers or contributors. This can be on [GitHub Issues](https://github.com/CSMarkBenchmark/CSMark/issues/) or elsewhere. This is the standard support provided for CSMark.

Some users may be eligible for Extended Support or Priority Support. These cases are handed on a case by case basis. Priority Support consists of support from Developers and Maintainers directly on Discord or Email and is only granted to certain users. Extended support consists of bug fixes and security updates to a version of CSMark after the verison no longer receieve mainstream support. This is also usually only available to select users.

__Question:__ Is the version of CSMark I'm using supported?
__Answer:__ You can check the status of CSMark support at the [CSMark Support Documentation](https://github.com/CSMarkBenchmark/CSMark/blob/master/Support.md).

__Question:__ Is my OS supported?
__Answer:__ If your OS isn't stated above then it's quite likely that it's not supported.
If you'd like to see an OS supported then please [suggest an improvement](https://github.com/CSMarkBenchmark/CSMark/issues/).
