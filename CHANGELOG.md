# Change Log

## 0.2.0

### New Features

- [create gatherings automatically from gathering templates](#changelog-heading-4371c61ecdba27fe0a91fb3b3dd12c521e177e73)

### Code Refactorings

- [add quartz cron job to create gatherings from gathering templates](#changelog-heading-51820a75f72946674d89cd765a975f522bd843c7)
- [rename asynchronous methods to mymethodasync](#changelog-heading-b88b3fd96ecf57d636d0177cc24023ea18aba205)
- [createdatroute location points to gettemplate](#changelog-heading-28be1d62ecfb32381cc8583a04d6929f0756e902)
- [add synchronous equivalent of async methods](#changelog-heading-b310e8a4e9f58754935c75111185b04bc7159fdc)
- [gathering dateandtime made to be unique](#changelog-heading-7be736d31352e7407b7946ce030b409be2ac5912)
- [remove Template from Gathering](#changelog-heading-0cb9329b667729b0535ea2c173891b97390a5612)

### Details

#### <a id="changelog-heading-4371c61ecdba27fe0a91fb3b3dd12c521e177e73"></a> create gatherings automatically from gathering templates

gathering templates are used to generate weekly gatherings. cron job running to execute task once a day

- Commit: `4371c61`

#### <a id="changelog-heading-51820a75f72946674d89cd765a975f522bd843c7"></a> add quartz cron job to create gatherings from gathering templates

- Commit: `51820a7`

#### <a id="changelog-heading-b88b3fd96ecf57d636d0177cc24023ea18aba205"></a> rename asynchronous methods to mymethodasync

naming convention recommends -async- as a suffic to asynchronous methods

- Commit: `b88b3fd`

#### <a id="changelog-heading-28be1d62ecfb32381cc8583a04d6929f0756e902"></a> createdatroute location points to gettemplate

createdatroute location erroneously pointed to createtemplate instead of get template

- Commit: `28be1d6`

#### <a id="changelog-heading-b310e8a4e9f58754935c75111185b04bc7159fdc"></a> add synchronous equivalent of async methods

some sync methods are required to be used by the program

- Commit: `b310e8a`

#### <a id="changelog-heading-7be736d31352e7407b7946ce030b409be2ac5912"></a> gathering dateandtime made to be unique

only one gathering should exist for a given datetime

- Commit: `7be736d`

#### <a id="changelog-heading-0cb9329b667729b0535ea2c173891b97390a5612"></a> remove Template from Gathering

no need to track Template Id for gatherings

- Commit: `0cb9329`

___

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

