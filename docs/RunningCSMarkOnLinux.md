## Running CSMark on Linux
You will need to [install DotNetCore 2.0.0 __Runtime__](https://www.microsoft.com/net/download/linux).

Check that you have a supported distro:
* Ubuntu 16.04 LTS or Ubuntu 17.04 or Linux Mint 18
* Debian 8 or Debian 9
* Fedora 25 or Fedora 26
* CentOS 7/RHEL 7/ Oracle Linux 7
* SUSE Linux Enterprise 12 SP2 +
* openSuse 42

### Installing
* For now, you'll have to download the CSMark ``linux-x64`` or ``linux-arm`` packages from the latest release pages.
* Once it's downloaded, move the zip file to wherever you want it to run CSMark from.
* Extract the zip file
* Navigate inside the ``publish`` folder.
* You should see a file named ``CSMarkRedux`` without any file extension. Give it permission to run as an exexcutable. You can do this visually or through the terminal.

![Image of how to visually enable executable permissions.](https://github.com/CSMarkBenchmark/CSMark/blob/master/assets/Linux_CSMarkRedux_Permissions.png)

* Finally, ``cd`` to wherever the publish folder is and run CSMark from the terminal  by typing ``./CSMarkRedux``

Your output should look something like this:
![Image of CSMark running on Linux](https://github.com/CSMarkBenchmark/CSMark/blob/master/assets/CSMarkOnLinux.png)
