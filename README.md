# 📚 Library Management System

A simple console app to manage a library using **C#**, **EF Core (Database First)**, and **SQL Server**.

---

## 🛠️ Technologies

- C# (.NET)
- Entity Framework Core
- SQL Server

---

## 📁 Project Structure

LibraryManagementSystem/



├── Models/ # Auto-generated EF Core models
├── Services/ # Business logic (BookService, AuthorService)
├── Program.cs # App entry point
└── README.md # This file




---

## ✅ Features

- Inserting authors and books
- Adding multiple books at once
- Adding a book with its author
- Updating and deleting data
- Using navigation between authors and books
- Eager vs Lazy loading
- Using `AsNoTracking()` for read-only queries
- Using `Attach()` to update without fetching
- Calling stored procedures

---

## ▶️ Getting Started

1. Create a database called `LibraryDB` in SQL Server.
2. Scaffold the models:
   ```bash
   Scaffold-DbContext "Server=.;Database=LibraryDB;Trusted_Connection=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
