# ProductProvider

## Overview
**ProductProvider** is a backend service built using **C#** and **ASP.NET Core Web API**. This microservice provides CRUD (Create, Read, Update, Delete) functionality for managing products. It allows clients to perform operations like adding new products, updating existing products, retrieving a list of products, retrieving a specific product, and deleting products.

## Features
- **Get all products**: Retrieve a list of all products.
- **Get one product**: Retrieve detailed information about a specific product by its ID.
- **Create product**: Add a new product to the system.
- **Update product**: Modify an existing product’s details.
- **Delete product**: Remove a product from the system.

## Endpoints

### 1. **GET /api/getproducts**
Retrieve a list of all products.

### 2. **GET /api/getproducts/{id}**
Retrieve the details of a specific product by its `id`.

**Parameters:**
- `id` (int): The unique identifier of the product.

### 3. **POST /api/createproduct**
Create a new product.

### 4. **PUT /api/updateproduct/{id}**
Update a product.

**Parameters:**
- `id` (int): The unique identifier of the product.

### 5. **DELETE /api/deleteproduct/{id}**
Delete a product.

**Parameters:**
- `id` (int): The unique identifier of the product.

### 6. **GET /api/sortproducts**
Sort a list of products.

- `SortOption` (int): Enum sortOption
- 0 = PriceAscending
- 1 = PriceDescending
- 2 = Alphabetical
- 3 = AlphabeticalDescending
