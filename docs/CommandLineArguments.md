## Command Line Arguments
This page documents what command line arguments can be used with CSMark CLI.

Failing to implement parameters in the correct order may cause the program to not recognize the parameter.

**Note:** When starting CSMark from another application, it should be noted that CSMark will take 3 seconds to display the License Agreement in the Console. The program will respond after the 3 seconds + the time taken to check for updates.

### With 2 parameters
* The 1st Parameter is  ``benchCommand`` - This is the CSMark command you'd like to use. E.g. ``bench``
* The 2nd Parameter is  ``accuracyLevel`` - This is the CSMark Accuracy Level you'd like to use. E.g. ``CM2`` . You may need to familiarize yourself with what Accuracy Levels there are in the current CSMark version.

### With 3 parameters
* The 1st Parameter is  ``benchCommand`` - This is the CSMark command you'd like to use. E.g. ``bench``
* The 2nd Parameter is  ``accuracyLevel`` - This is the CSMark Accuracy Level you'd like to use. E.g. ``CM2`` . You may need to familiarize yourself with what Accuracy Levels there are in the current CSMark version.
* The 3rd Parameter is ``saveToFile`` and must be set to either ``True`` or ``False``.