# Pet Store App

A C# console application for managing a pet store's inventory, staff accounts, and customers. Originally built as a university coursework project further edited to learn password encryption and testing in C#.

## Features

- **Employee accounts** — add/remove employees, with passwords hashed using Argon2id (never stored or written to disk in plaintext)
- **Customer accounts** — register customers and detect returning customers
- **Product catalog** — pets (dogs, cats, fish, lizards, hamsters, snakes) and supplies (enclosures, food, decorations, health items, toys), all implementing a shared `IPurchasables` interface
- **CSV persistence** — employee and customer records are loaded from and saved to CSV files between sessions
- **Unit tested** — an xUnit test suite covering password hashing, employee management, and pet data

## Tech stack

- .NET 8 / C#
- [xUnit](https://xunit.net/) for testing
- [Isopoh.Cryptography.Argon2](https://github.com/mheyman/Isopoh.Cryptography.Argon2) for password hashing

## Getting started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

## Project structure

```
AE1/           Main console application
  Pets.cs, Dog.cs, Cat.cs, ...    Pet catalog (implements IPurchasables)
  Supplies.cs, Food.cs, ...       Store supplies
  Workers.cs / Customers.cs       Employee and customer management (implement Humans, ICSVManager)
  Hashing.cs                      Argon2id password hashing wrapper
  uiManager.cs                    Console menu and program flow
  Program.cs                      Entry point

AE1.Tests/     xUnit test suite
```

## Design notes

- Employee passwords are hashed with Argon2id before being stored or written to CSV — plaintext passwords are never persisted.
- `Pets` and `Supplies` both implement a common `IPurchasables` interface so items can be listed and priced generically, regardless of category.
- `Workers` and `Customers` share a common `Humans` base class and an `ICSVManager` interface for consistent load/save behavior.

Employee and customer records are read from and written to `Customers.csv` / `EmployeeCodes.csv` in the working directory the app is run from.
