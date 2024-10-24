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
```
## Main Components
- **DTOs (Data Transfer Objects): Used for transferring data between system layers**.
- **Repositories: Handle data access logic.**
- **Mappings: Uses AutoMapper to map entities to DTOs.**
- **Services: Contain the business logic of the application.**
## Features
Employee Management:

Create, update, list, and delete employees.
CPF validation using CPFValidationAttribute.
Automatic address filling using the ViaCEP service.
Product Management:

CRUD operations for products.
## Endpoints
Below are some of the main API endpoints:

## Employees
```plaintext
GET /api/employees - Retrieve all employees.
GET /api/employees/{id} - Retrieve a specific employee.
POST /api/employees - Add a new employee.
PUT /api/employees/{id} - Update an existing employee.
DELETE /api/employees/{id} - Delete an employee.
```
## Products
```plaintext
GET /api/products - Retrieve all products.
GET /api/products/{id} - Retrieve a specific product.
POST /api/products - Add a new product.
PUT /api/products/{id} - Update an existing product.
DELETE /api/products/{id} - Delete a product.
```
## Usage Example
Here’s an example of how to create a new employee using cURL:
```bash
curl -X POST "https://localhost:5001/api/employees" \
-H "Content-Type: application/json" \
-d '{
    "Name": "John Doe",
    "Role": "Manager",
    "City": "New York",
    "Salary": 5000.00,
    "CPF": "12345678909",
    "PostalCode": "10001",
    "PublicPlace": "Broadway",
    "Complement": "Apt 10",
    "Uf": "NY",
    "State": "New York",
    "Region": "Northeast",
    "Ddd": "212"
}'
```
## Contributing
To contribute to this project, follow these steps:

Fork the repository.
Create a new branch for your feature:
bash
Copiar código
```bash
git checkout -b my-feature
```
Commit your changes:
bash
Copiar código
```bash
git commit -m "Add my feature"
```
Push the branch:
bash
Copiar código
```bash
git push origin my-feature
````
Open a Pull Request.
