### Todo

- [ ] Refactor
  - [ ] Update User Registration to return CreatedAtRouteResult
  - [ ] Set CreateWeeklyGatheringsFromGatheringTemplates to use UnitOfWork instead of DbContext

- [ ] Documentation
  - [ ] Classes
  - [ ] Methods
  - [ ] Properties

- [ ] Testing
  - [ ] Create multiple options for database types (see here)[https://docs.microsoft.com/en-us/ef/core/testing/testing-sample]
    - [ ] In-Memory
    - [ ] SQLite
    - [ ] SQL Server

### In Progress

- [ ] Refactor
  - [ ] Create non-asynchronous methods where appropriate

### Completed

- [x] Implement ChangeLog generator
  - [x] Add changelog.settings.json to solution root
- [x] Implement StyleCop
- [x] Implement SonarAnalyzer
- [x] Create GatheringTemplate Controller
  - [x] Build tests for template CRUD methods
  - [x] Build template CRUD methods
- [x] Refactor
  - [x] Rename all asynchronous methods to MyMethodAsync