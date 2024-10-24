# SuperMarket API

Welcome to the **SuperMarket API**, a management application for employees and products in the supermarket sector. This API was built using **C#** and **ASP.NET Core**, supporting CRUD operations and custom validations, such as CPF validation.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Project Structure](#project-structure)
- [Features](#features)
- [Endpoints](#endpoints)
- [Usage Example](#usage-example)
- [Contributing](#contributing)
- [License](#license)

## Prerequisites

Before getting started, ensure you have the following installed:

- **.NET Core SDK 7.0** or later
- **SQL Server** or another supported database
- **Entity Framework Core**

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/supermarket-api.git
    ```

2. Navigate to the project folder:

    ```bash
    cd supermarket-api
    ```

3. Restore the dependencies:

    ```bash
    dotnet restore
    ```

4. Build the project:

    ```bash
    dotnet build
    ```

## Configuration

Before running the project, configure your database connection string in the `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=SuperMarketDB;User Id=your_user;Password=your_password;"
  }
}
````
After configuring the connection string, apply the migrations to create the database:
```bash
dotnet ef database update
````
## Project Structure
Here’s an overview of the project structure:
```plaintext
SuperMarket.API/
├── SuperMarket.Core/
│   ├── Domain/
│   ├── DTO/
│   └── Services/
├── SuperMarket.Data/
│   ├── Contexts/
│   ├── Repositories/
│   └── Mappings/
└── SuperMarket.Tests/


