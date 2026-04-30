# 🎮 GameZone

GameZone is a web-based gaming platform built using **ASP.NET Core MVC**.
It allows users to explore games, write reviews, and interact with game content, while providing an **Admin Dashboard** for managing the system.

---

## 🚀 Features

### 👨‍💼 Admin Panel

* Full **CRUD Operations** for Games
* Upload and manage game images
* Add and manage Admin users
* Secure access using role-based authorization

---

### 👤 User Features

* Browse available games
* View game details
* Add reviews to games
* View all reviews for each game

---

## 🧠 Architecture & Design

The project is built using the **ASP.NET Core MVC pattern**.

It also incorporates the following design patterns and practices:

* **Generic Repository Pattern** → for reusable data access logic
* **Unit of Work Pattern** → to manage transactions efficiently
* **Service Layer** → to handle business logic and keep controllers clean
* **Custom Validation Attributes** → for handling file validation

---

## 🧩 Custom Validation

The project includes custom attributes for validating uploaded files:

### 📁 AllowedExtensions

Restricts file uploads to specific extensions.

```csharp
[AllowedExtensions(".jpg,.png")]
public IFormFile Image { get; set; }
```

---

### 📏 MaxSizeAllowed

Limits the maximum file size.

```csharp
[MaxSizeAllowed(2 * 1024 * 1024)] // 2MB
public IFormFile Image { get; set; }
```

---

## ⚡ AJAX Integration

The project uses **jQuery AJAX** to:

* Submit reviews without reloading the page
* Improve responsiveness and user experience

---

## 🛠️ Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* ASP.NET Identity
* jQuery & AJAX
* Bootstrap

---

## 📂 Project Structure

```bash
GameZone
│── Controllers
│── Attributes
│── Data
│   ├── Configuration
│   ├── Repositories
│   ├── ApplicationDbContext.cs
│── Services
│   ├── Interfaces
│   ├── Implementation
│── Models
│── ViewModels
│── Views
│── wwwroot
│── Migrations
│── Helper
│── Settings
```

---

## 🔄 System Workflow

1. Admin logs into the system
2. Admin manages games and admins
3. Images are validated using custom attributes
4. User registers / logs in
5. User browses games
6. User submits reviews using AJAX
7. Reviews are saved and displayed dynamically

---

## 🔐 Authentication & Authorization

* Implemented using **ASP.NET Identity**
* Roles:

  * Admin
  * User

---

## 📌 Future Improvements

* Add real-time features using SignalR
* Implement game rating system ⭐
* Improve UI/UX
* Add advanced search and filtering

---

## 🤝 Contribution

Feel free to fork the repository and submit pull requests.

---

## 👨‍💻 Author

**Mohamed Gomaa**

---
