# SuperMarket Management System

## Description

This project is a SuperMarket Management System developed in C# that allows users to manage products, employees, and roles in a supermarket environment. The system includes various functionalities such as:

- Adding products with details such as price, expiration date, and stock quantity.
- Managing employee roles.
- Validating CPF (Brazilian ID number).
- Calculating final prices with discounts.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
- [Usage](#usage)
- [Class Structure](#class-structure)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Product Management**: Add, edit, and manage products including attributes like name, price, expiration date, stock quantity, and category.
- **Role Management**: Manage employee roles using enums to define different roles in the system.
- **CPF Validation**: Validate the CPF number of employees.
- **Inventory Tracking**: Track available stock and update it during purchases.
- **Discount Calculation**: Automatically calculate final price based on discounts.
- **Expiration Date Handling**: Check if a product has expired.

## Technologies

- **C#**
- **.NET Framework**
- **Object-Oriented Programming (OOP)**

## Setup

1. Clone the repository to your local machine:
    ```bash
    git clone https://github.com/yourusername/SuperMarketSystem.git
    ```

2. Open the solution file in Visual Studio:
    ```bash
    SuperMarketSystem.sln
    ```

3. Build the project by pressing `Ctrl+Shift+B` in Visual Studio or navigating to `Build > Build Solution`.

4. Run the project using `Ctrl+F5` or navigating to `Debug > Start Without Debugging`.

## Usage

Once the system is up and running, you can perform various actions like:

- Adding a new product:
    ```csharp
    Products product = new Products();
    product.ProductName = "Milk";
    product.Price = 5.99;
    product.ExpirationDate = DateTime.Parse("2024-10-10");
    product.StockQuantity = 50;
    product.Category = "Dairy";
    ```

- Checking if a product is expired:
    ```csharp
    bool isExpired = product.IsExpired();
    ```

- Adding stock to a product:
    ```csharp
    product.AddStock(20);
    ```

- Validating CPF for an employee:
    ```csharp
    bool isValid = employee.IsValidCPF(employee.CPF);
    ```

## Class Structure

### `Products`

A class representing the products in the supermarket. The class includes properties such as:

- `ProductName`: The name of the product.
- `Price`: The price of the product.
- `ExpirationDate`: The expiration date of the product.
- `StockQuantity`: The quantity of the product in stock.
- `Category`: The category the product belongs to (e.g., food, cleaning supplies, etc.).

Methods in the `Products` class:

- `GetFinalPrice()`: Calculates the final price of the product considering discounts.
- `IsExpired()`: Checks if the product is expired.
- `AddStock()`: Increases the stock quantity.
- `ReduceStock()`: Decreases the stock quantity after a purchase.

### `Employee`

A class for managing employee information. This includes properties such as:

- `Name`
- `Age`
- `CPF`
- `Role`: Enum-based role assignment.

The class includes validation methods like `IsValidCPF()` to ensure the CPF is correctly formatted.

### `RoleEnum`

An enum that defines different roles for employees:

```csharp
public enum RoleEnum
{
    Manager,
    Security,
    Butcher,
    Attendant,
    DeliveryProfessional,
    Stockist,
    MerchandiseRepository,
    Packer,
    Cashier,
    Cleaners
}
