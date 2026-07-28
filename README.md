# NoteWebApi

ASP.NET Core 9 Web API for managing notes and users with JWT authentication, Entity Framework Core, and SQL Server.

## Features

- JWT Bearer authentication (login + protected note endpoints)
- Notes CRUD (authorized)
- User registration and listing
- FluentValidation for request validation
- AutoMapper for entity/DTO mapping
- BCrypt password hashing
- EF Core + SQL Server
- Swagger / OpenAPI with Bearer token support

## Requirements

- .NET 9 SDK
- SQL Server (LocalDB or full instance)
- EF Core tools (`dotnet tool install --global dotnet-ef`)

## Configuration

Update `NoteWebApi/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=NoteAppDB;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "JwtSettings": {
    "SecretKey": "YOUR_LONG_SECRET_KEY_AT_LEAST_32_CHARS",
    "Issuer": "NotesApi",
    "Audience": "NotesApiClient"
  }
}
```

## Run

```bash
dotnet restore
dotnet ef database update --project NoteWebApi
dotnet run --project NoteWebApi
```

Swagger UI: `https://localhost:7192/swagger`

## Auth flow

1. Create a user: `POST /api/User`
2. Login: `POST /api/Auth/login` → returns `{ "token": "..." }`
3. In Swagger, click **Authorize** and paste the token (without `Bearer ` prefix if Swagger already adds it)
4. Call note endpoints with the JWT

Token lifetime: **60 minutes**.

## API Endpoints

### Auth

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/api/Auth/login` | No | Login and get JWT |

**Login body**

```json
{
  "username": "mahir",
  "password": "YourPassword123"
}
```

### Users

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `POST` | `/api/User` | No | Register user |
| `GET` | `/api/User` | No | List users |
| `GET` | `/api/User/{id}` | No | Get user by id |

**Create user body**

```json
{
  "userName": "mahir",
  "userEmail": "mahir@example.com",
  "password": "YourPassword123"
}
```

### Notes (requires JWT)

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| `GET` | `/api/Notes` | Yes | List notes |
| `GET` | `/api/Notes/{id}` | Yes | Get note by id |
| `POST` | `/api/Notes` | Yes | Create note (owner = logged-in user) |
| `PUT` | `/api/Notes/{id}` | Yes | Update note |
| `DELETE` | `/api/Notes/{id}` | Yes | Delete note |

**Create / update note body**

```json
{
  "title": "Meeting notes",
  "content": "Discuss API auth and ownership"
}
```

## Project structure

```
NoteWebApi/
├── Controllers/          # Auth, Notes, User
├── Dtos/                 # Request/response models
├── Entities/             # Note, User
├── Datas/                # AppDbContext
├── Mapping/              # AutoMapper profiles
├── Migrations/           # EF Core migrations
├── Repository/           # Data access
├── Services/             # Business logic
└── Validators/           # FluentValidation rules
```

## Notes

- `Notes` are linked to `Users` via `UserId` (cascade delete).
- Passwords are stored as BCrypt hashes, never plain text.
- Do not commit real production secrets; keep JWT `SecretKey` and connection strings out of public repos when possible.
