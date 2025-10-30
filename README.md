#Web API with SQL Server — Clean Architecture (ASP.NET Core 9)

> A learning project to build a **RESTful API** using **ASP.NET Core 9**, **Entity Framework Core**, and **SQL Server**.  
> Implements **Clean Architecture**, **Repository Pattern**, **AutoMapper**, and **Exception Middleware** for structured and maintainable backend development.

---

##Project Overview

This project demonstrates how to build a full-featured **CRUD Web API** that connects to a **real SQL Server database**, following modern software architecture principles.

###Key Features
- Full CRUD operations for **Product** and **Category**
- **Entity Framework Core** integration with SQL Server
- **Repository Pattern** for clean data access
- **AutoMapper** for DTO <-> Entity mapping
- **Data Validation** using `[Required]`, `[StringLength]`, `[Range]`
- **Global Exception Handling Middleware**
- **Swagger UI** for API documentation and testing
- Built using **Clean Architecture** principles

---

##🧱 Project Structure
│
├── Api/
│ ├── Controllers/ → ProductsController.cs
│ ├── Middleware/ → ExceptionMiddleware.cs
│ ├── Program.cs → Application entry point
│ └── appsettings*.json → Environment configurations
│
├── Application/
│ ├── DTOs/ → ProductDto, CategoryDto
│ ├── IServices/ → IProductService interface
│ ├── IRepositories/ → IProductRepository interface
│ ├── Services/ → ProductService (business logic)
│ └── Mapping/ → AutoMapper profile configuration
│
├── Domain/
│ ├── Entities/ → Product.cs, Category.cs
│ ├── Enums/ → ProductStatus.cs
│ ├── Constants/ → TableNames.cs
│
└── Infrastructure/
├── Persistence/ → AppDbContext.cs, Configurations/
├── Repositories/ → ProductRepository.cs
├── Seeders/ → AppDbSeeder.cs
└── Migrations/ → EF Core migrations

---

##Prerequisites & Extensions

Before running the project, make sure you have the following:

###**Software Requirements**
| Tool | Version / Note |
|------|----------------|
| **.NET SDK** | 9.0 or later |
| **SQL Server** | 2019 / 2022 |
| **Visual Studio Code** | or Visual Studio 2022 |
| **Entity Framework CLI** | Install via `dotnet tool install --global dotnet-ef` |

###**VS Code Extensions**
| Extension | Purpose |
|------------|----------|
| **C# (by Microsoft)** | Syntax highlighting and IntelliSense |
| **NuGet Package Manager** | Manage dependencies |
| **SQL Server (mssql)** | View and query SQL databases |
| **REST Client / Thunder Client** | Test API requests inside VS Code |

---

##Dependencies

The main NuGet packages used:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Swashbuckle.AspNetCore

