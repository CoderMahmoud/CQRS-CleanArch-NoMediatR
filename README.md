## 🧱 Architecture Overview

This project follows **Clean Architecture** principles using **Vertical Slice Architecture**.

Each feature owns its full vertical slice (Presentation → Application → Domain → Infrastructure), ensuring high cohesion and low coupling.

---

## 🚀 Features

- ASP.NET Core 9 Web API
- CQRS pattern without MediatR
- Vertical slice architecture (folders by feature)
- Clean separation of concerns with custom abstractions
- EF Core InMemoryDatabase (no SQL Server required)
- Simple User CRUD (Create & Get by ID & Get by Username && Delete)

---

## 📁 Folder Structure

```
WebApi/
│
├── Application/
│ ├── Abstractions/
│ │ └── Messaging/
│ │ ├── ICommand.cs
│ │ ├── ICommandHandler.cs
│ │ ├── IQuery.cs
│ │ └── IQueryHandler.cs
│ │
│ └── Features/
│ └── Users/
│ ├── Commands/
│ │ ├── RegisterUser/
│ │ │ ├── RegisterUserCommand.cs
│ │ │ └── RegisterUserHandler.cs
│ │ └── DeleteUser/
│ │ ├── DeleteUserCommand.cs
│ │ └── DeleteUserHandler.cs
│ │
│ └── Queries/
│ ├── GetUserById/
│ │ ├── GetUserByIdQuery.cs
│ │ └── GetUserByIdHandler.cs
│ └── GetUserByUserName/
│ ├── GetUserByUserNameQuery.cs
│ └── GetUserByUserNameHandler.cs
│
├── Controllers/
│ └── UserController.cs
│
├── Domain/
│ ├── Entities/
│ │ └── User.cs
│ └── Repositories/
│ ├── IUserRepository.cs
│ └── UserRepository.cs
│
├── Infrastructure/
│ └── InMemoryDbContext.cs
│
├── appsettings.json
├── Program.cs

---

## 📦 Tech Stack

- [.NET 9](https://dotnet.microsoft.com/en-us/)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [EF Core InMemory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/)
- C# 13
- CQRS (manually implemented)

---

## 📬 Example API Endpoints

### Create User

`POST /api/users`

**Request Body:**

{
  "username": "Mahmoud",
  "email": "mahmoud@example.com",
}

**Response:**
`201 Created`

{
  "UserId":"00000000-0000-0000-0000-000000000000"
}
---
### Get User by ID

`GET /api/users/{id}`

**Response:**
```json
{
  "UserId": "00000000-0000-0000-0000-000000000000",
  "UserName": "Mahmoud",
  "Email": "mahmoud@example.com"
}
```

---

## 🧰 Project Principles

- ✅ **CQRS without third-party dependencies**
- ✅ **Vertical Slice** — features grouped by functionality
- ✅ **Clean Architecture** via folder-based separation
- ✅ **SOLID Principles** applied with reusable interfaces

---

## 📌 To Do

- [ ] Add FluentValidation for input
- [ ] Add Unit Tests

---

## 📝 License

MIT License. Use freely for learning or commercial projects.
