## Commands
These are the officially supported CLI commands in CSMark.

### Bench
The ``bench`` command runs both the single-threaded and multi-threaded test. It runs the single threaded tests first and the multi-threaded tests afterwards.
This is advised for comparing performance of CPUs across different manufacturers or architectures.

### Bench_Single
The ``bench_single`` command runs the single threaded test only. The multi-threaded test is not run. At the end of the test, the single threaded results will be displayed to the Console.
This is advised for comparing performance of CPUs across different manufacturers or architectures.

### Bench_Multi
The ``bench_multi`` command runs the multi threaded test only. The single-threaded test is not run. At the end of the test, the single threaded results will be displayed to the Console.
This is advised for comparing performance of CPUs across the same architecture or manufacturer but only if the single threaded results are not required.

### Stress_Test
The ``stress_test`` command runs the Stress Test Utility. This can be configured to run for a specified period of time or to run until you tell it to stop.

### About
The ``about`` command lists the CSMark version, CSMarkLib version and AutoUpdaterNetStandard version.

### Clear
The ``clear`` command clears the entire Console and cleans it up so that there is only the commands list and space for you to type in another command.
If you haven't saved scores or taken screenshots of scores, I'd recommend doing so before running ``clear``.

### Help
The ``help`` command lists all the commands and references the Documentation Contents Page.
