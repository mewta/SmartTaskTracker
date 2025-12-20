# Smart Task & Time Tracker API (.NET 8)

##  Overview

Smart Task & Time Tracker is a backend REST API built using **ASP.NET Core Web API (.NET 8)**. The project allows users to manage projects, tasks, and time entries with secure **JWT-based authentication**. It was developed as part of an internship assignment to demonstrate backend development, database design, and API security concepts.

---

## Features

### Authentication

* User Registration
* User Login
* JWT-based authentication & authorization
* Secure password hashing using BCrypt

### Project Management

* Create projects
* View all projects
* Update project details (name, description, status)

### Task Management

* Create tasks under projects
* View tasks by project
* Update task status (Pending → InProgress → Completed)

### Time Tracking

* Add time entries to tasks
* View time entries per task
* Get total hours spent on a task

---

##  Tech Stack

* **ASP.NET Core Web API (.NET 8)**
* **SQL Server** (Docker)
* **Entity Framework Core (Code First)**
* **JWT Authentication**
* **Swagger / OpenAPI**
* **Git & GitHub**

---

## Project Structure

```
SmartTaskTracker.API
│
├── Controllers
│   ├── AuthController.cs
│   ├── ProjectsController.cs
│   ├── TasksController.cs
│   └── TimeEntriesController.cs
│
├── Data
│   ├── AppDbContext.cs
│   └── AppDbContextFactory.cs
│
├── DTOs
│   ├── Auth
│   ├── Projects
│   ├── Tasks
│   └── TimeEntries
│
├── Helpers
│   ├── JwtTokenGenerator.cs
│   └── PasswordHasher.cs
│
├── Models
│   ├── User.cs
│   ├── Project.cs
│   ├── TaskItem.cs
│   └── TimeEntry.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

## Authentication Flow (Swagger)

1. **POST /api/auth/register** – Register a user
2. **POST /api/auth/login** – Login and get JWT token
3. Click **Authorize** in Swagger
4. Enter:

```
Bearer <your_token_here>
```

5. Access secured endpoints

---

## API Endpoints

### Auth

* `POST /api/auth/register`
* `POST /api/auth/login`

### Projects

* `POST /api/projects`
* `GET /api/projects`
* `PUT /api/projects/{id}`

### Tasks

* `POST /api/projects/{projectId}/tasks`
* `GET /api/projects/{projectId}/tasks`
* `PUT /api/tasks/{id}/status`

### Time Entries

* `POST /api/tasks/{taskId}/time-entries`
* `GET /api/tasks/{taskId}/time-entries`
* `GET /api/tasks/{taskId}/time-entries/total-hours`

---

## Testing

* APIs tested using **Swagger UI**
* JWT-protected endpoints validated using Authorization header

---

## Database

* EF Core Code-First approach
* Migrations used for schema creation
* Relationships:

  * Project → Tasks (One-to-Many)
  * Task → TimeEntries (One-to-Many)

---

## How to Run

1. Clone the repository
2. Start SQL Server (Docker)
3. Update connection string in `appsettings.json`
4. Run migrations:

```bash
dotnet ef database update
```

5. Run the API:

```bash
dotnet run
```

6. Open Swagger:

```
http://localhost:5078/swagger
```

---

## Status

Core features completed 
JWT authentication implemented
Swagger documentation available
Ready for evaluation / submission

---

## Author

**Maitri**

Internship Project – Smart Task & Time Tracker



Test protected endpoints

Project Status

All required features have been implemented according to the assignment specifications, including authentication, CRUD operations, relationships, and documentation.
