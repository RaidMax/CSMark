# Contribution Guide

**Table Of Contents**

[What should I know before I get started?](#what-should-i-know-before-i-get-started)

[Code Of Conduct](#code-of-conduct)

[Setting up your environment](#setting-up-your-environment)

[How to submit changes](#how-to-submit-changes)

[How to suggest enhancements](#suggesting-enhancements)

[How to report a bug](#how-to-report-a-bug)

[Building Release Binaries](#building-release-binaries)

[Where do I Chat with maintainers?](#chat-with-maintainers)

[How do I get recognized for my contributions?](#contribution-recognition)

## What should I know before I get started
CSMark is not a tiny project. It takes advantage of OOP to try to modularize components and that means that making changes are usually pretty easy.

![Image of CSMark Project Overview](https://github.com/AluminiumTech/CSMark/blob/master/assets/csmarkProjOverview.PNG)

You can see above that all the types of calculations that are carried out have a class in the Calculations folder. All the benchmark tests have their own class,
in the folder and each class manages the running of that particular benchmark test.

CSMark is built using C# DotNetCore. Due to the nature of our benchmarks, we don't want to support 32 Bit Devices unless we have to (such as on Mobile).
It is also important to acknowledge that CSMark is cross-platform and works on Windows, Mac and Linux. This is important to note because each release which is published should contain
binaries for as many platforms as is reasonable. Any new code that is added must be able to run on Windows, Mac or Linux. 

This means that whilst we accept Platform Adaptive Code (or PAC for short) (E.g. run `methodPC();` on Windows, `methodMac();` on Mac or `methodLinux();` on Linux), we generally prefer a native cross-platform piece of code (we can call this NCP for short). An example of this is the file saving functionality in CSMark.

Below is some code for saving a file. You can see that we create a folder for the results inside of the current directory for CSMark. This means that we don't have to worry about if the code can run on Windows but not Mac because we know all platforms can safely create a folder within their current directory.

Code from Program.cs
``score.saveToTextFile(Directory.GetCurrentDirectory() + "\\results", CSMarkVersion, benchAccuracy, accuracyConfigured);``

Code from the ScoreSaver Class:
``Console.WriteLine("The file was saved at ... " + directory);``

The same goes for other possible conflict areas. In addition, this code saves the user the trouble of having to spend a long time finding where the results files are.
Notice that the program also tells the user where they can find the results. Because of the way DotNet on Windows is implemented, users can easily copy the directory and paste it into the File Explorer to navigate straight to it.
The user should always be informed about what is going on. 

Users don't often have to be told why they can't do something, but when it happens it needs to be clear and concise language which lets the user know what the problem is.
For example, let's say the user has a CPU with 6 Cores and 12 Threads. It is common knowledge among PC enthusiasts that higher core count CPUs may not necessarily be the highest single threaded performers out there for a variety of reasons include clockspeed or architecturally.
Thus we can safely assume that running a single threaded only benchmark on a heavily multi-threaded CPU is a waste of time. In the code example below, we can politely inform the user why they can't run it. But doing this can be a little bit complicated as we need to have multiple checks in place to make sure we don't stop all users from being able to use it.

```
if (benchAccuracy == "MX1" & Environment.ProcessorCount >= 4 & newCommand == "bench-multi" || benchAccuracy == "MX2" & Environment.ProcessorCount >= 4 & newCommand == "bench-multi"){
   Console.WriteLine("Your CPU is probably too powerful for this accuracy level. Please try a different accuracy level.");
    continue;
      }
    else if (benchAccuracy == "MX1" & newCommand != "bench-multi") {
     maxIterations = 0.2 * 1000.0 * 1000 * 1000;
          }
     else if (benchAccuracy == "MX2" & newCommand != "bench-multi") {
       maxIterations = 0.5 * 1000.0 * 1000 * 1000;
       }     
  ```
  
These are the kind of quality of life improvements we need to implement to ensure that the user has a pleasant experience.

## Setting up your environment
Setting up your environment for developing CSMark would normally be pretty straight forward except for how many options there are to do so.

Below I've listed the different recommendations for different OS users.

### Setting up your environment on Windows
Developing CSMark on Windows is pretty straight forward. 
* I recommend downloading [Visual Studio 2017](https://www.visualstudio.com) - Ensure that you have selected the DotNetCore package for installation.
* You should download [GitHub Desktop](https://desktop.github.com/) to be able to easily [submit changes](#how-to-submit-changes)

You don't need to download anything else to get setup.  If you'd like to try out CSMark on a system without the DotNetCore SDKs (the SDK is included in the Visual Studio DotNetCore package), you may want to download the [DotNetCore Runtime](https://www.microsoft.com/net/download/core#/runtime).

If you want to use [VS Code](https://visualstudio.com/code) instead then that also works however I don't 100% recommend it for debugging.

### Setting up your environment on macOS
Developing CSMark on Mac is a little bit complicated but not impossible.
* I recommend downloading [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/).
* You'll need to install the latest version of OpenSSL. The easiest way to do that is through [HomeBrew](https://brew.sh/)

Once you've installed HomeBrew, you'll need to install OpenSSL.
```
    brew update
    brew install openssl
    mkdir -p /usr/local/lib
    ln -s /usr/local/opt/openssl/lib/libcrypto.1.0.0.dylib /usr/local/lib/
    ln -s /usr/local/opt/openssl/lib/libssl.1.0.0.dylib /usr/local/lib/
```
* You should download [GitHub Desktop](https://desktop.github.com/) to be able to easily [submit changes](#how-to-submit-changes)

You don't need to download anything else to get setup. If you'd like to try out CSMark on a system without the DotNetCore SDK (the SDK is included in the Visual Studio DotNetCore package), you may want to download the [DotNetCore Runtime](https://www.microsoft.com/net/download/core#/runtime).

### Setting up your environment on Linux
So, you're running that hip cool thing called Linux?

If you happen to run one of the few Linux Distros supported and the version you're using is supported then this is for you.
In DotNetCore 2.0, more Linux distros will be supported along with a generic Linux-x64 binary for platforms which don't have dedicated binaries.

* You'll probably want to install [VS Code](https://visualstudio.com/code). I know I said that Windows users shouldn't necessarily use it but that's only because they have access to the VS IDE.
* Youi'll want to download the latest [DotNetCore SDK for Linux](https://www.microsoft.com/net/download/linux) (We're using DotNetCore 1.1 at the moment so make sure to install the correct SDK for that version.

In all honesty, you can use any Git client you like. GitHub currently doesn't have a linux version of their new GitHub desktop program but I suspect that we could see a linux build in the future.
For now though, any Git client will work but you'll have to configure it yourself.

## How to submit changes
You can submit changes by:
1. Forking this repository - It's as simple as pressing that fork button.
2. Cloning your fork of the repository onto your PC - This can be through GitHub Desktop's easy cloning functionality or through Git Clone on any computer.
3. Make whatever changes you want to make
4. Test the changes and debug the app to make sure you haven't introduced any new bugs.
5. Create a Pull request
6. Fill in the required details specified in the Pull Request Template - Make sure that your title does not include an issue number.
7. Include screenshots if possible
8. Avoid Platform Dependant Code. Use Platform Adaptive Code or Native Cross Platform code.
9. Wait for a Maintainer to check your Pull Request. If it's up to standard and provides meaningful improvements such as new features or bug fixes, then Maintainers can accept the Pull Request and Merge it into the main branch.

## Building Release Binaries
So, you want to build release binaries of CSMark?

You'll need all the SDKs and Tools mentioned above in [Setting up your environment](#setting-up-your-environment).

Creating binaries currently requires using the .NET CLI Build commands. I've listed them below for your convenience.
You can run the commands from any Shell such as CMD on Windows or Terminal on Mac or Linux.

For Windows 10 64 Bit: `` dotnet publish -c Release -r win10-x64  ``
For Windows 10 ARM 64 Bit: `` dotnet publish -c Release -r win10-arm64  ``
For Windows 10 ARM 32 Bit: `` dotnet publish -c Release -r win10-arm  ``
For Windows 7 SP1 64 Bit: `` dotnet publish -c Release -r win7-x64  ``
For Windows 8.1 64 Bit: `` dotnet publish -c Release -r win81-x64  ``
For macOS 10.12 "Sierra": `` dotnet publish -c Release -r osx.10.12-x64 ``
For 64 Bit Linux Distros: `` dotnet publish -c Release -r linux-x64  ``
For ARM 32 Bit Linux Distros: `` dotnet publish -c Release -r linux-arm  ``

The license file has been set to be copied every time you create a new binary so you don't need to worry about that.

You may wish to ZIP the files for publishing or distributing them.

The Windows Installers for CSMark releases are typically made using [Inno Setup](http://www.jrsoftware.org/isinfo.php).
That doesn't mean that if you make your own releases that you have to. You can use [NSIS](http://nsis.sourceforge.net/Main%5FPage) if you're more familiar with that.

## Code Of Conduct
Everybody participating in the CSMark project must abide by the [CSMark Code of Conduct](https://github.com/AluminiumTech/CSMark/blob/master/CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code.
Please report unacceptable behavior to aluminiumdev@gmail.com.

## How to report a bug
This section guides you through submitting a bug report for CSMark.

### Before submitting a bug report
* Check to see if there an existing bug report for the bug you've experienced.
* If you find a Closed issue that seems like it is the same thing that you're experiencing, open a new issue and include a link to the original issue in the body of your new one.

### How do I submit a good bug report?
Bugs in CSMark are tracked as [GitHub issues](https://guides.github.com/features/issues/). 
Create an issue following [the template](https://github.com/AluminiumTech/CSMark/blob/master/ISSUE_TEMPLATE.md).

Explain the problem & include various information to help maintainers reproduce the problem:
* Use a clear and descriptive title - Maintainers should be able to have a good idea about what issue you're experiencing before they click on your issue.
* Describe exactly how to reproduce the problem - State what you did and how you did them.
* Describe the behavior you observed after following the steps and point out what exactly is the problem with that behavior.
* Explain which behavior you expected to see instead and why.
* If the problem wasn't triggered by a specific action, describe what you were doing before the problem happened and share more information using the guidelines below
* Can you reliably reproduce the issue? If not, provide details about how often the problem happens and under which conditions it normally happens.

## Suggesting Enhancements
* Use a clear and descriptive title for the issue to identify the suggestion - It should be obvious to maintainers exactly what you want. Try to keep it under 150 characters.
* Provide a step-by-step description of the suggested enhancement in as many details as possible.
* Describe the current behavior and explain which behavior you expected to see instead and why.
* State what version of CSMark you're using
* State the name and version of the OS you're using.

## Chat with Maintainers
Maintainers are really awesome people. They look after projects and make sure that everything runs smoothely.

If you want to chat with other people about CSMark and it's development then check out our [Slack Chat](https://join.slack.com/t/csmark/shared_invite/MjI1MjE2MTQ0ODgxLTE1MDI1MDU3MzMtNGVmYmQxMzYzNg)

## Contribution Recognition
Thank you for contributing to this project! You're awesome :) .

We detail your great contributions in our [Authors file](https://github.com/AluminiumTech/CSMark/blob/master/Authors.md).
