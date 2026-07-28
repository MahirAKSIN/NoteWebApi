# NoteWebApi

ASP.NET Core 9 Web API for managing notes and users with Entity Framework Core and SQL Server.

## Features

- Notes CRUD endpoints
- User creation and user listing/get-by-id endpoints
- FluentValidation for request validation
- AutoMapper for entity/DTO mapping
- BCrypt password hashing for stored user passwords
- EF Core + SQL Server
- Swagger / OpenAPI in development

## Recent Updates

- Added `User` entity and `Notes -> User` relationship
- Added user DTOs, validator, repository, service, and controller layers
- Registered user dependencies in DI container
- Added EF Core migration for user table and note-user relationship

## Requirements

- .NET 9 SDK
- SQL Server (LocalDB or full instance)

## Configuration

Update the connection string in `NoteWebApi/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=NoteAppDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

## Run

```bash
dotnet restore
dotnet ef database update --project NoteWebApi
dotnet run --project NoteWebApi
```

Swagger UI: `https://localhost:<port>/swagger`
