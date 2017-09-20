# Contributing Translations
This documents outlines how users can contribute translations to CSMark.

## Notes
Locales are stored in .resx files in CSMark. This is how translations can easily be added.

### How to contribute translations if you are a code contributor
1. Users who are code contributors can create a new .resx file in the format of ``locale_`` + locale + ``.resx`` such as ``locale_EN.resx``and add all the fields required.
2. Simply replace the contents of the copied file with the translations as appropriate by double clicking on the file and using the Visual Editor (VS2017 only)
3. Once you've made all the translations you can. Please inform a maintainer so they can add support for it.

### How to contribute translations if you are not a code contributor
1. Please make an issue [(See Contributing Guide if you're unsure)](https://github.com/CSMarkBenchmark/CSMark/blob/master/CONTRIBUTING.md) with "Language Contributions - " and "[language]" in the title.
2. Remove the contents of the Issue Template which populates the area by default.
3. Provide a list of the phrases translations with English on the Left and Your Language on the right E.g. ``Yes -> Oui``.
4. Once you're confident you've contributed as much as you are able to. Please submit the issue and let maintainers add this into CSMark.

If you are unsure of anything please ask a maintainer.
