# Library Management System

A pragmatic Library Management System built with ASP.NET Core MVC. Implements SOLID principles, real authentication & authorization, borrowing transactions, and fully protected routes.

---

## Table of Contents

- [Project Structure](#project-structure)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [Authentication & Authorization](#authentication--authorization)
- [Borrowing Transactions](#borrowing-transactions)
- [SOLID Principles](#solid-principles)
- [License](#license)

---

## Project Structure

/bin
/Controllers
/Migrations
/Models
/obj
/Properties
/Repository
/ViewModel
/Views
/wwwroot
appsettings.json
appsettings.Development.json
LibraryManagementSystem.csproj
Program.cs



- **Controllers**: Handle HTTP requests, actions, and business logic.
- **Models**: Define database entities and core data structures.
- **Repository**: Abstracts and handles all data operations.
- **ViewModel**: Data passed between controllers and views.
- **Views**: Razor views for the UI.
- **Migrations**: Entity Framework migrations.
- **wwwroot**: Static assets (CSS, JS, images).
- **Configuration**: App settings and project files.

---

## Features

- User registration and login
- Role-based authorization (admin, user)
- **Protected routes**—no access for unauthenticated users
- CRUD operations for books and users
- Borrowing transactions (borrow and return books)
- History of borrow/return activity per user
- Clean project structure following SOLID and repository pattern
- Extensible, maintainable, ready for real-world use

---

## Tech Stack

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server** (or any compatible DB)
- **C#**
- **Razor Views**
- **Bootstrap** (if used)

---

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/AhmedAmeen1/LibraryManagementSystem
   cd LibraryManagementSystem


2. **Restore Dependencies**
  dotnet restore

3. **Restore Dependencies**
  Edit appsettings.json with your DB connection string.

4. **Run EF migrations**
  dotnet ef database update

5. **Start the app**
  dotnet run

6. **Visit in your browser**
Visit in your browser:
Open https://localhost:5001 (or the port configured).




Authentication & Authorization
Uses ASP.NET Identity for managing users and roles.

Registration, login, and logout for users.

Role-based access:

Admin: Full permissions (manage books, users, view all transactions).

User: Can view books and manage their own borrowing activity.

Protected routes:

Unauthenticated users cannot access any book or transaction routes.

Borrowing Transactions
Users can borrow and return books.

Admins can view all transactions.

Transaction history is linked to each user.

Validation to prevent borrowing the same book twice, or borrowing unavailable books.

SOLID Principles
Built from the ground up with SOLID in mind:

Single Responsibility: Each component does one thing and does it well.

Open/Closed: Easy to extend with new features, hard to break existing ones.

Liskov Substitution: Interfaces and inheritance done right.

Interface Segregation: No bloated interfaces.

Dependency Inversion: Controllers and services depend on abstractions, not concrete classes.
