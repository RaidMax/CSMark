## Issues Status
This is a table of all Issues found and reported in CSMark. CSMark versions affected as well as a description of each bug is available.

| Issue ID | Issue Type | CSMark Versions Affected | CSMark Versions Patched |Description of Issue | Description of Fix Required | Severity | Status |
|----------|------------|--------------------------|----------------------|--------------------|----------|----------|----------|
| CSM-9 | Bug | 0.16.0 - 0.16.1, Possibly 0.14.3 or newer | - | CSMark will attempt to save the score to a file however the scores saved and scaling may be incorrect. | | Moderate |  |
| CSM-8 | Bug | 0.16.0 - 0.16.1, Possibly 0.14.3 or newer | - | CSMark will attempt to check for updates when running on Linux and crashes regardless even if the user has internet access. | Fix may involve tweaking check for update URL/RID string  | Moderate |  |
| CSM-7 | Bug | 0.16.0 - 0.16.1, Possibly 0.14.3 or newer | - | CSMark will attempt to check for updates and crashes regardless if the user has internet access or not. | Add an exception to handle when CSMark is not able to get the current version of the application. | Moderate | |
| CSM-6 | Bug | 0.14.0 to 0.14.1 |0.14.2 | GeomtricSumN Scaling results shows ArithmeticSumN scaling instead of GeometricSumN Scaling | Fixed the method used to return scaling. | Moderate | Patched on August 26th 2017 |
| CSM-5 | Bug | 0.13.0 to 0.13.3 | 0.13.4 | Multi-threaded results were shown as being 0. | Fixed returning multi-threaded calculations. | Moderate | Patched on August 20th 2017|
| CSM-4    | Bug/Vulnerability | 0.3.0 to 0.13.2 | 0.9.2, 0.10.1, 0.11.1, 0.12.1 and 0.13.3 | Stress Test can continue if attempt to use the "break" command is unsuccessful | Ensure that if the command to stop the stress test fails, stop the stress test anyways. | Severe | Patched on August 14th 2017|
| CSM-2    | Bug | 0.13.0 | 0.13.1 | Accuracy Level was not reset after each benchmark run. | After each iteration of the Program While Loop, the accuracy is reset to the default value. | Moderate| Patched on August 11th 2017 |
| CSM-3    | Bug | 0.13.0 to 0.13.1 | 0.13.2 | Multi-threaded results were not normal after running Bench Average | Removal of Bench Average | Moderate | Patched on August 11th 2017|
| CSM-1    | Bug | 0.4.0.0 to 0.9.0 | 0.6.1, 0.7.1, 0.8.1, 0.9.1 and 0.10.0 |  | Iteration must be reset to 0 before a benchmark is run. | Moderate | Patched on July 11th 2017 |




