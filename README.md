# Book Store API

ASP.NET Core Web API learning project demonstrating a layered architecture and
common production-facing HTTP API concerns.

## Features

- Books and categories with Entity Framework Core and PostgreSQL
- Repository and service layers
- Filtering, sorting, searching, pagination and data shaping
- JWT authentication and refresh tokens with ASP.NET Core Identity
- API versioning, HATEOAS links and content negotiation
- JSON, XML and CSV response formats
- Response caching, cache headers and IP rate limiting
- Centralized exception handling and NLog integration
- Swagger/OpenAPI documentation

## Project structure

```text
Entities/       Domain models, DTOs, request parameters and exceptions
Repositories/   EF Core context, repositories and query extensions
Services/       Application services, authentication and logging
Presentation/   Controllers, filters and HTTP link generation
WebApi/         Composition root, configuration and migrations
```

## Prerequisites

- .NET 9 SDK
- PostgreSQL

## Configuration

Secrets are not committed. Set the database connection and JWT signing key with
environment variables before running the API:

```bash
export ConnectionStrings__DefaultConnection='Host=localhost;Port=5432;Database=ApplicationDb;Username=postgres;Password=replace-me'
export JwtSettings__secretKey='replace-with-a-long-random-development-secret'
```

The remaining issuer, audience and expiration settings are defined in
`WebApi/appsettings.json` and may also be overridden with environment variables.

## Build and run

```bash
dotnet restore bsStoreApp.sln
dotnet build bsStoreApp.sln --no-restore
dotnet run --project WebApi/WebApi.csproj
```

Swagger UI is available in the Development environment at the URL printed by
the application, followed by `/swagger`.

## Security

- Repository configuration files contain no credentials.
- Authentication secrets must be supplied by the runtime environment.
- Generated application and NLog files are excluded from version control.

This project is an educational portfolio application and should receive an
independent security review before any production deployment.
