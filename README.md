# 🎮ة GameZone

GameZone is a scalable web-based gaming platform built with **ASP.NET Core MVC** that allows users to explore games, write reviews, and interact with game content. The system also provides a powerful **Admin Dashboard** for managing games and administrators.

---

##  Features

###  Admin Panel

* Full **CRUD Operations** for Games
* Upload game images with validation
* Manage Admin accounts
* Control system access using role-based authorization

---

###  User Features

* Browse all available games
* View game details
* Add and view reviews
* Explore feedback from other users

---

 Architecture & Design Patterns

The project is designed using clean architecture principles:

* **Generic Repository Pattern**
  Abstracts data access logic and promotes reusability

* **Unit of Work Pattern**
  Ensures consistency across multiple database operations

* **Service Layer**
  Handles business logic separately from controllers

* **ASP.NET Identity**
  Provides secure authentication & role-based authorization

---

## 🛠️ Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* ASP.NET Identity
* jQuery & AJAX
* Bootstrap

---

## ⚡ AJAX Integration

AJAX is used to:

* Submit reviews without reloading the page
* Fetch dynamic data
* Improve user experience

---

## 🧩 Custom Validation Attributes

The system includes **custom validation attributes** for handling file uploads:

### 📁 AllowedExtensions Attribute

* Restricts uploaded files to specific extensions
* Prevents unsupported file types

```csharp
[AllowedExtensions(".jpg,.png")]
public IFormFile Image { get; set; }
```

---

### 📏 MaxSizeAllowed Attribute

* Limits file size for uploads
* Prevents large file submissions

```csharp
[MaxSizeAllowed(2 * 1024 * 1024)] // 2MB
public IFormFile Image { get; set; }
```

---

### ✅ Benefits

* Enhances security
* Improves validation at the model level
* Keeps controllers clean

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

1. Admin logs in
2. Admin adds/updates games
3. Images are validated using custom attributes
4. User logs in
5. User browses games
6. User submits reviews via AJAX
7. Reviews are stored and displayed instantly

---

## 🔐 Authentication & Authorization

* Implemented using **ASP.NET Identity**
* Roles:

  * Admin
  * User

---

## 📌 Future Enhancements

* Real-time features using SignalR
* Game rating system ⭐
* Advanced filtering & search
* API integration

---

## 🤝 Contribution

Contributions are welcome! Feel free to fork and submit pull requests.

---

## 👨‍💻 Author

**Mohamed Gomaa**

---
