# Ziur Tech Test

Technical assessment for Ziur
A Blazor app that consumes a real API and presents its data in a searchable sortable catalog.

## What it does

- Document catalog loaded from the API, with search by code or description and sorting by any column.
- Loading, empty and error states, with a retry action when a request fails.

## Getting started

### Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (same major version as the one in `ZiurTest.csproj`)

### Configuration

The API address and any credentials are not committed
Set them with user secrets:

```bash
dotnet user-secrets init
dotnet user-secrets set "Api:Token" "123example"
```

### Run it

```bash
git clone https://github.com/kiyota-sh/ziur-test.git
cd ZiurTest
dotnet restore
dotnet run # or dotnet watch
```

## Commit conventions

|     Type     |                       Meaning                       |
| :----------: | :-------------------------------------------------: |
|   **feat**   |                    New features                     |
|   **fix**    |                      Bug fixes                      |
| **breaking** |                   Breaking change                   |
|  **build**   |            Changes in compilation system            |
|  **chore**   |  Changes that don't affect production environment   |
|    **ci**    | Changes in the continuous integration configuration |
|   **docs**   |              Changes in documentation               |
|   **perf**   |               Updates in performance                |
| **refactor** |                Refactoring processes                |
|  **revert**  |       Rollbacks to previous commit or changes       |
|  **style**   |                  Changes in syntax                  |
|   **test**   |                  Add or fix tests                   |

## Author

Camilo Solarte, Full Stack Developer

- Email: kamoxbit@gmail.com
- Phone: +57 311 4442998
- LinkedIn: [camilo-solarte](https://linkedin.com/in/camilo-solarte/)
- GitHub: [Kiyota-sh](https://github.com/Kiyota-sh)
- Salary expectation: $ 3.500.000 COP (base salary, per month)