Smart Task & Time Tracker API (.NET 8)
Overview

Smart Task & Time Tracker is a backend REST API built using ASP.NET Core (.NET 8) that allows users to manage projects, tasks, and track time spent on tasks. The application uses JWT-based authentication to secure all endpoints except registration and login.

This project was developed as part of an internship assignment to demonstrate understanding of Web API development, authentication, database design, and clean backend architecture.

Tech Stack

ASP.NET Core Web API (.NET 8)

Entity Framework Core (Code First)

SQL Server (Docker)

JWT Authentication

Swagger (OpenAPI)

Git & GitHub

Core Features
Authentication

User registration

User login

JWT-based authentication

Secure access to all protected endpoints

Project Management

Create projects

View all projects

Update project details (name, description, status)

Task Management

Create tasks under a project

View tasks by project

Update task status (Pending, InProgress, Completed)

Time Tracking

Add time entries for tasks

View time entries per task

Get total hours spent on a task

Database Design

One-to-many relationship: Project → Tasks

One-to-many relationship: Task → TimeEntries

EF Core Code-First approach with migrations

API Endpoints
Authentication
POST /api/auth/register
POST /api/auth/login

Projects
POST /api/projects
GET /api/projects
PUT /api/projects/{id}

Tasks
POST /api/projects/{projectId}/tasks
GET /api/projects/{projectId}/tasks
PUT /api/tasks/{id}/status

Time Entries
POST /api/tasks/{taskId}/time-entries
GET /api/tasks/{taskId}/time-entries
GET /api/tasks/{taskId}/time-entries/total-hours


All endpoints except login and registration require JWT authentication.

Running the Project
Prerequisites

.NET SDK 8.0

Docker

SQL Server container running

Steps

Clone the repository

Start SQL Server using Docker

Update the connection string in appsettings.json

Apply migrations:

dotnet ef database update


Run the API:

dotnet run


Open Swagger at:

http://localhost:5078/swagger

Testing with Swagger

Register a user using /api/auth/register

Login using /api/auth/login and copy the JWT token

Click Authorize in Swagger

Paste the token as:

Bearer <your_token>


Test protected endpoints

Project Status

All required features have been implemented according to the assignment specifications, including authentication, CRUD operations, relationships, and documentation.
