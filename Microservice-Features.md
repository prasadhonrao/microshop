# Microservice Features

- Unit tests
- Integration tests
- Functional tests
- Code coverage
- Async APIs
- Stream support
- CRUD, search, pagination and deferred execution support
- HTTP status codes
- Collection support
- Caching support
- OpenAPI specification
- Dev - Prod configuration
- Consistent code pattern
- CI / CD pipelines using GitHub Actions
- Security (Authentication and Authorization)
- Centralized logging
- Repository and UoW patterns for data access
- Versioning
- Multiple output formatters - JSON, XML
- gRPC support
- File based add, update, delete
- Data Transfer Object
- Circuit breaker support
- HATEOAS
- Concurrency
- Markdown documentation

## Running Migration

dotnet ef migrations add Initial
dotnet ef database drop
dotnet ef database update
