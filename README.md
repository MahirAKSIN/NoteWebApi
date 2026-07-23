# NoteWebApi

ASP.NET Core 9 Web API for managing notes with Entity Framework Core and SQL Server.

## Features

- Notes CRUD endpoints
- EF Core + SQL Server
- Swagger / OpenAPI in development

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
