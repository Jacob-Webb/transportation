# Change Log

## 0.1.3

### Documentation Changes

- [auto generate changelog](#changelog-heading-6e7ca9f272d974a649731721d653b7fcfe11fb4a)

### Code Refactorings

- [convert events to gatherings](#changelog-heading-b77d15d01f422f3cfc53dcf9ac9b6f4a79558a89)
- [add stylecop and sonaranalyzers to test project](#changelog-heading-2d02483796022aed7700a901fa445a8cec4e17d7)
- [create NoMap attribute](#changelog-heading-45f8ca10f047a17904557617185944fc2c202a1e)
- [add response types to gatheringtemplatecontroller methods](#changelog-heading-0930320fee0490ab858a230f374663dfd4dea1d8)

### Build System and Dependency Changes

- [Add Moq to test project](#changelog-heading-4c843c381a500b5a7480b0019098774e2f6b080d)

### Details

#### <a id="changelog-heading-6e7ca9f272d974a649731721d653b7fcfe11fb4a"></a> auto generate changelog

- Commit: `6e7ca9f`

#### <a id="changelog-heading-b77d15d01f422f3cfc53dcf9ac9b6f4a79558a89"></a> convert events to gatherings

The term event could be ambigous and mistaken for events inside the program. Gatherings is more specific to mean a place and time where people will meet.

- fix: ambiguity in the term event
- Commit: `b77d15d`

#### <a id="changelog-heading-2d02483796022aed7700a901fa445a8cec4e17d7"></a> add stylecop and sonaranalyzers to test project

- Commit: `2d02483`

#### <a id="changelog-heading-45f8ca10f047a17904557617185944fc2c202a1e"></a> create NoMap attribute

allow for multiple properties from source object to be ignored by automapper to the destination object

- Commit: `45f8ca1`

#### <a id="changelog-heading-0930320fee0490ab858a230f374663dfd4dea1d8"></a> add response types to gatheringtemplatecontroller methods

swagger and documentation is made less ambiguous to the client by providing possible response status

- Commit: `0930320`

#### <a id="changelog-heading-4c843c381a500b5a7480b0019098774e2f6b080d"></a> Add Moq to test project

- Commit: `4c843c3`

___

## 0.1.2

#### <a id="changelog-heading-514a0dc051b090de71683d299e4ca417bcdde8fb"></a> update changelog settings file

- Commit: `514a0dc`
___

## 0.1.1

### Documentation Changes

- [update changelog with changelog-csharp generator](#changelog-heading-063c2d2f702696399e7cb7a894c444e4c1854805)

### Code Refactorings

- [implement code rules for sonaranalyzer.csharp](#changelog-heading-9d4ca40f5c8730df3c0de5c599c0e1df3c560472)

### Details

#### <a id="changelog-heading-063c2d2f702696399e7cb7a894c444e4c1854805"></a> update changelog with changelog-csharp generator

- Commit: `063c2d2`

#### <a id="changelog-heading-9d4ca40f5c8730df3c0de5c599c0e1df3c560472"></a> implement code rules for sonaranalyzer.csharp

sonaranalyzer.csharp was added to project and these changes reflect that

- Commit: `9d4ca40`

___

## 0.1.0

### Code Refactorings

- [apply coding rules to config and controller classes](#changelog-heading-fd7cb34a0a191c39be2634fd651b4516b31d6996)
- [update code styling to align with stylecop ruleset](#changelog-heading-91d405e97606026d534fe8d4adbf07d407c8d33f)
- [add documentation to gitignore](#changelog-heading-408e13726224d8cd73c81ca28f020fcd721a8bd4)
- [finalize stylecop ruleset adherance](#changelog-heading-6808b83ad244579f95ecdb622ad6140d52bd70ab)

### Build System and Dependency Changes

- [add warning suppression in .editorconfig file](#changelog-heading-c0388bec8f74da0cb28c27746fd1d2006ca0edc6)

### Details

#### <a id="changelog-heading-fd7cb34a0a191c39be2634fd651b4516b31d6996"></a> apply coding rules to config and controller classes

- Commit: `fd7cb34`

#### <a id="changelog-heading-91d405e97606026d534fe8d4adbf07d407c8d33f"></a> update code styling to align with stylecop ruleset

- Commit: `91d405e`

#### <a id="changelog-heading-408e13726224d8cd73c81ca28f020fcd721a8bd4"></a> add documentation to gitignore

- Commit: `408e137`

#### <a id="changelog-heading-6808b83ad244579f95ecdb622ad6140d52bd70ab"></a> finalize stylecop ruleset adherance

- Commit: `6808b83`

#### <a id="changelog-heading-c0388bec8f74da0cb28c27746fd1d2006ca0edc6"></a> add warning suppression in .editorconfig file

naming convention warnings could not be suppressed by stylecop.json or the ruleset file

- Commit: `c0388be`

___

## 0.0.0

### Documentation Changes

- [add changelog to todo](#changelog-heading-56b176e41948ef5131fe1f6b93d672e9a316217a)

### Code Refactorings

- [move coding style rulesets to RuleSet](#changelog-heading-2e360b0c748901f096db78ec394598ae5cd080c5)

### Build System and Dependency Changes

- [add style rulesets for files](#changelog-heading-e82534a7293e9dff8a14765c4e63f71f431d04d4)

### Details

#### <a id="changelog-heading-56b176e41948ef5131fe1f6b93d672e9a316217a"></a> add changelog to todo

- Commit: `56b176e`

#### <a id="changelog-heading-2e360b0c748901f096db78ec394598ae5cd080c5"></a> move coding style rulesets to RuleSet

- Commit: `2e360b0`

#### <a id="changelog-heading-e82534a7293e9dff8a14765c4e63f71f431d04d4"></a> add style rulesets for files

include stylecop ruleset and json file to enforce coding styles across files

- Commit: `e82534a`

