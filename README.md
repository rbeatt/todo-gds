# TodoGDS

This repository contains a .NET 8.0 ASP.NET Core MVC web application named TodoGDS, designed for managing todo items. It uses Entity Framework Core with SQLite for local development and SQL Server for production deployments. The app includes Razor views, controllers, and static assets (e.g., GOV.UK frontend styles), with database migrations for schema management.

## Features

- Create, read, update, and delete (CRUD) todo items.
- Responsive UI using GOV.UK frontend components.
- Database switching: SQLite for development, SQL Server for production.
- Entity Framework Core migrations for database schema management.

## Prerequisites

- .NET 8.0 SDK
- Visual Studio Code or Visual Studio 2022
- SQLite (for development) or SQL Server (for production)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/rbeatt/todo-gds.git
   cd TodoGDS
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

## Database Setup

### Development (SQLite)
- The app automatically uses SQLite in development mode.
- Run migrations to set up the database:
  ```bash
  dotnet ef database update
  ```

### Production (SQL Server)
- Configure the connection string in `appsettings.json` or via environment variables (e.g., Azure App Service settings).
- Apply migrations to the production database:
  ```bash
  dotnet ef database update
  ```

## Usage

1. Run the application:
   ```bash
   dotnet run
   ```

2. Open your browser and navigate to `https://localhost:5001` (or the configured port).

3. Use the web interface to manage todo items.

## Deployment

- For Azure deployment, set the production connection string in Azure App Service configuration.
- Ensure the database is accessible and migrations are applied.

## Contributing

1. Fork the repository.
2. Create a feature branch.
3. Make your changes and test them.
4. Submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
