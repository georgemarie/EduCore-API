# EduCore API

EduCore API is a RESTful Web API built with ASP.NET Core for managing students and departments. It is designed with clean architecture principles, focusing on security, maintainability, and performance.

## Key Features

* **Security:** ASP.NET Core Identity integrated with JWT (JSON Web Tokens) for authentication.
* **Session Management:** Refresh Token rotation for secure, long-lived user sessions.
* **Role-Based Access Control (RBAC):** Distinct permissions for 'Admin' and 'Student' roles.
* **Clean Architecture:** Implements the Repository Pattern and Unit of Work to decouple the data access layer.
* **Performance:** Fully asynchronous endpoints utilizing CancellationToken to terminate database queries on dropped client requests.
* **Error Handling & Logging:** Global exception middleware and integrated NLog for structured application logging.

## Technologies

* C# & .NET
* Entity Framework Core (Code-First)
* Microsoft SQL Server
* ASP.NET Core Identity

## API Endpoints Overview

### Authentication (`/api/Account`)
* `POST /RegisterAdmin` - Creates an Admin user.
* `POST /RegisterStudent` - Creates a Student user.
* `POST /Login` - Authenticates and returns JWT & Refresh Token.
* `POST /RefreshToken` - Renews an expired JWT.

### Departments (`/api/Department`) - Requires Admin Role
* `GET /`, `GET /{id}`, `POST /`, `PUT /`, `DELETE /{id}`

### Students (`/api/Student`)
* `GET /`, `GET /{id}`, `GET /{name}`, `POST /`, `PUT /`, `DELETE /{id}`

## Author
George Beshara
