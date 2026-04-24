# 📚 BookStore - Library Management System

## 🧾 Description

BookStore is a web application developed using **ASP.NET Core MVC with C#** that allows basic management of a library. The system includes functionalities to manage users, books, and loans, implementing CRUD operations and essential business rules.

---

## 🎯 Objective

Develop an administrative interface that allows:

* Managing users
* Managing books
* Registering and controlling loans
* Applying validations in both the interface and business logic

---

## 🏗️ Project Architecture

The system follows the **MVC (Model-View-Controller)** pattern:

```
BookStore/
│
├── Models/          → Core entities (User, Book, Loan)
├── ViewModels/      → View-specific models (LoanViewModel)
├── Controllers/     → Handles HTTP requests
├── Services/        → Business logic layer
├── Data/            → DbContext and database configuration
├── Views/           → User interface (Razor)
└── Responses/       → Message handling (Success, Warning, Danger, Info)
```

---

## ⚙️ Features

### 👤 Users

* Create users
* List users
* Edit users
* Delete users
* Email and required field validation

---

### 📚 Books

* Create books
* List books
* Edit books
* Delete books
* Availability control (`IsLoaned`)
* Required field validation

---

### 🔄 Loans

* Register book loans
* Select user and book from dropdown lists
* Prevent loaning already loaned books
* Release book when loan is deleted
* Show only available books in the form

---

## 🧠 Validations Implemented

### ✔ UI Validations (DataAnnotations)

* `[Required]`
* `[EmailAddress]`
* `[StringLength]`
* `[Range]`

### ✔ Backend Validations (Services)

* Prevent duplicates (users/books)
* Validate data existence
* Block loans for unavailable books

### ✔ Error Handling

* `ModelState` validation
* Custom exceptions (`BusinessException`)
* Visual alerts using Bootstrap

---

## 🎨 Interface

* Forms with real-time validation
* Dynamic messages using `TempData`
* Styled alerts with Bootstrap
* Simple navigation between modules

---

## 🗄️ Database

Uses **Entity Framework Core** with migrations:

### Main commands:

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

---

## 🚀 Loan Flow

1. Select user
2. Select available book
3. Register loan
4. Automatically update book status
5. Deleting a loan releases the book

---

## 🧪 Technologies Used

* ASP.NET Core MVC
* C#
* Entity Framework Core
* Razor Views
* Bootstrap 5
* jQuery Validation

---

## 📌 Project Status

✔ Full CRUD implemented
✔ Frontend and backend validations
✔ Business logic applied
✔ Fully functional loan system

---

## 📈 Future Improvements

* Loan history (without deleting records)
* Return system with dates
* Dashboard with statistics
* User authentication
* Pagination and search

---

## 👨‍💻 Author

Developed by: Faiber Camacho

The system was developed with the aim of creating and implementing a bookstore management system initially built using MVC and clean architecture principles.

---
