# Task Management Application with User Authentication

## Problem Statement
This project involves developing a full-stack Task Management Application where users can log in, manage tasks, and perform CRUD operations. The application is fully Dockerized for seamless deployment. The backend uses .NET Core with Onion Architecture and PostgreSQL as the database, while the frontend is built using React Native (Expo).

## Tech Stack
- **Frontend:** React Native, Redux Toolkit, Axios
- **Backend:** .NET Core (ASP.NET Core), PostgreSQL, Entity Framework Core, JWT Authentication, Swagger
- **Docker:** Containerization for frontend, backend, and database services

---

## Features
- **Frontend:**
  - User login and JWT authentication.
  - Persistent authentication using AsyncStorage.
  - Screens for login, task creation, and task management.
  - CRUD operations for tasks.

- **Backend:**
  - User registration and login with JWT.
  - Secure endpoints for task management.
  - PostgreSQL integration using Entity Framework Core.
  - Swagger documentation for all APIs.

- **Docker:**
  - Frontend, backend, and database fully containerized.
  - Docker Compose for service orchestration.

---

## Local Setup Instructions

### Prerequisites
1. Install the following tools:
   - Node.js and npm
   - Expo CLI
   - .NET Core SDK (6.0 or above)
   - PostgreSQL
   - Docker and Docker Compose (for Dockerized setup)

2. Clone the project repository:
   ```bash
   git clone <repository-url>
   cd TaskManagementApp
Backend Setup
Navigate to the backend folder:

  ```bash

   cd backend/TaskManagementBackend

Restore dependencies:

dotnet restore
Configure the PostgreSQL connection string in appsettings.json.

Apply database migrations:

dotnet ef database update
Start the backend:

dotnet run

Frontend Setup
Navigate to the frontend folder:

cd frontend
Install dependencies:

npm install
Start the application using Expo:

expo start
Use Expo Go or an emulator to test the application.
