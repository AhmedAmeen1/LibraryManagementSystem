📚 Library Management System
A pragmatic Library Management System built with ASP.NET Core MVC. Implements SOLID principles, real authentication & authorization, borrowing transactions, and fully protected routes.

<div align="center">
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=io/badge/c%23-%23239120.svg?style=forServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor/badge/bootstrap-%23563D7C.svg?style of Contents

🏗️ Project Structure

✨ Features

🛠️ Tech Stack

🚀 Getting Started

🔐 Authentication & Authorization

📖 Borrowing Transactions

🎯 SOLID Principles

📄 License

🏗️ Project Structure
text
📦 LibraryManagementSystem
├── 📁 bin/
├── 📁 Controllers/          # 🎮 HTTP request handlers
├── 📁 Migrations/           # 🗃️ Database migrations
├── 📁 Models/               # 📊 Data entities
├── 📁 obj/
├── 📁 Properties/
├── 📁 Repository/           # 🏪 Data access layer
├── 📁 ViewModel/            # 📋 View data models
├── 📁 Views/                # 🖼️ Razor UI templates
├── 📁 wwwroot/              # 🌐 Static assets
├── ⚙️ appsettings.json
├── ⚙️ appsettings.Development.json
├── 📄 LibraryManagementSystem.csproj
└── 🚀 Program.cs
✨ Features
Feature	Description
👤 User Management	Registration, login, and profile management
🛡️ Role-Based Access	Admin and user roles with different permissions
🔒 Protected Routes	Secure endpoints - no unauthorized access
📚 Book Management	Full CRUD operations for library catalog
🔄 Borrowing System	Seamless book borrowing and return process
📊 Transaction History	Complete audit trail of all activities
🏗️ Clean Architecture	SOLID principles and repository pattern
🔧 Extensible Design	Ready for real-world deployment and scaling
🛠️ Tech Stack
<div align="center">
Technology	Purpose
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=flatio/badge/Entity%20Framework-512BD4?style=flat-square&logo=dotnet&logoColor=whiteelds.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor	
![Razor](https://img.shields.io/badge/Razor-512BD4?style=flat-square&logo=dotnet&logoColor	
✅ .NET 6.0 or later

✅ SQL Server (LocalDB or full instance)

✅ Visual Studio 2022 or VS Code

Installation
📥 Clone the repository

bash
git clone https://github.com/AhmedAmeen1/LibraryManagementSystem
cd LibraryManagementSystem
📦 Restore dependencies

bash
dotnet restore
⚙️ Configure database

Edit appsettings.json with your connection string:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=true"
  }
}
🗃️ Apply migrations

bash
dotnet ef database update
🚀 Run the application

bash
dotnet run
🌐 Open in browser

Navigate to: https://localhost:5001

🔐 Authentication & Authorization
<div align="center">
Role	Permissions
👑 Admin	- Manage all books
- View all users
- Access all transactions
- System administration
👤 User	- Browse book catalog
- Borrow/return books
- View personal history
- Manage profile
</div>
🛡️ Security Features
✅ ASP.NET Identity integration

✅ Secure password hashing

✅ Session management

✅ Route protection

✅ CSRF protection

✅ Input validation

📖 Borrowing Transactions
🔄 Workflow
text
graph LR
    A[📚 Browse Books] --> B{Available?}
    B -->|Yes| C[📋 Borrow Request]
    B -->|No| D[❌ Wait for Return]
    C --> E[✅ Book Borrowed]
    E --> F[📅 Due Date Set]
    F --> G[📖 Reading Period]
    G --> H[📤 Return Book]
    H --> I[✅ Transaction Complete]
📊 Features
🚫 Duplicate Prevention: Can't borrow the same book twice

📅 Due Date Tracking: Automatic due date calculation

📈 Usage Analytics: Track popular books and user activity

🔍 Search & Filter: Find books by title, author, or category

🎯 SOLID Principles
Our architecture follows SOLID principles for maintainable, scalable code:

Principle	Implementation
🎯 Single Responsibility	Each class has one clear purpose
🔓 Open/Closed	Easy to extend, protected from modification
🔄 Liskov Substitution	Proper inheritance and interface usage
🧩 Interface Segregation	Focused, specific interfaces
🔀 Dependency Inversion	Depend on abstractions, not concretions
🏗️ Architecture Benefits
✅ Testable: Easy unit testing with dependency injection

✅ Maintainable: Clear separation of concerns

✅ Scalable: Add features without breaking existing code

✅ Flexible: Swap implementations easily

🤝 Contributing
We welcome contributions! Please see our Contributing Guidelines for details.

🍴 Fork the repository

🌿 Create a feature branch

💻 Make your changes

✅ Add tests

📝 Submit a pull request

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.

<div align="center">
🌟 Star this repository if you found it helpful!
Built with ❤️ by Ahmed Ameen

</div>
📞 Support
Having issues? We're here to help!

🐛 Report a Bug

💡 Request a Feature

📧 Contact Support
