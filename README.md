# Smart Task & Time Tracker API

A backend REST API built using **ASP.NET Core (.NET 8)** to manage projects, tasks, and time tracking with **JWT authentication**.

This project was developed as part of an internship assignment to demonstrate backend development, database design, and secure API practices.

---

## 🚀 Tech Stack

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (Code First)
- SQL Server (Docker)
- JWT Authentication
- Swagger (API Documentation)
- Git & GitHub

---

## 🔐 Features

### Authentication
- User Registration
- User Login
- JWT-based Authentication
- Secured endpoints using `[Authorize]`

### Project Management
- Create Project
- View Projects
- Update Project (name, description, status)

### Task Management
- Create Tasks under a Project
- View Tasks by Project
- Update Task Status (Pending → InProgress → Completed)

### Time Tracking
- Add Time Entries for Tasks
- View Time Entries
- Calculate Total Hours per Task

---

## 🗂 Database Design

- **Project → Tasks** (One-to-Many)
- **Task → TimeEntries** (One-to-Many)
- EF Core migrations used for schema management


---

## 📘 API Documentation

Swagger UI is available after running the application:

http://localhost:{PORT}/swagger:


All endpoints except **login** and **register** are secured using JWT authentication.

---

## ▶️ How to Run

1. Start SQL Server using Docker
2. Update `appsettings.json` with your connection string
3. Apply migrations:
```bash
dotnet ef database update

Run the API:
dotnet run

