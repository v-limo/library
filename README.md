# Library

## Postgres image and connections string

```bash
docker run --name db-postgres -e POSTGRES_PASSWORD=MyVeryStrongPassword123! -e POSTGRES_USER=postgres -e POSTGRES_DB=bookdb  -p 5432:5432 -v app_data:/var/lib/postgresql/data --network apinetwork -d postgres

```

```json
{
  "DefaultConnection": "Server=localhost;Port=5432;Database=bookdb;User Id=postgres;Password=MyVeryStrongPassword123!;Pooling=true;"
}
```

### Database migrations and update
```bash
 dotnet ef migrations add InitialCreate --verbose --project ./src/LibraryApp.Infrastructure/LibraryApp.Infrastructure.csproj --startup-project ./src/LibraryApp.WebApi/LibraryApp.WebApi.csproj


dotnet ef database update   --project ./src/LibraryApp.Infrastructure/LibraryApp.Infrastructure.csproj --startup-project ./src/LibraryApp.WebApi/LibraryApp.WebApi.csproj
```


```bash
 dotnet run --project ./src/LibraryApp.WebApi/
```

## Up the API
  - TODO: Fix persistance

```bash
docker compose -f "docker-compose.yml" up -d --build
```
