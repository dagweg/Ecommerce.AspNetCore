# Ecommerce Platform

<div align="center">
<img src="https://img.shields.io/badge/.Net%20Core-blue?logo=.net" alt=".Net Core" > <img src="https://img.shields.io/badge/AutoMapper-yellow" alt="AutoMapper" > <img src="https://img.shields.io/badge/Fluent%20Validation-rgb(162,94,207)" alt="Fluent Validation" > <img src="https://img.shields.io/badge/FluentAssertions-rgb(33,156,125)" alt="FluentAssertions" > <img src="https://img.shields.io/badge/xUnit-rgb(188,42,107)" alt="xUnit" > <img src="https://img.shields.io/badge/Serilog-cyan" alt="Serilog" > <img src="https://img.shields.io/badge/Moq-blueviolet?logo=moq" alt="Moq" > <img src="https://img.shields.io/badge/MediatR-red" alt="MediatR" > <img src="https://img.shields.io/badge/OpenAPI%20Swagger-rgb(255,87,51)?logo=swagger" alt="OpenAPI Swagger" > <img src="https://img.shields.io/badge/Entity%20Framework%20Core-purple" alt="Entity Framework Core" > <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-rgb(81,73,136)?logo=MySql" alt="Microsoft SQL Server" >
</div>

## Overview

An Ecommerce WebService built with .NET Core following Clean Architecture, DDD, CQRS and SOLID principles.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet) installed.
- Database: Ensure you have [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) running locally.

### Installation

1. Clone the repository

```bash
git clone https://github.com/dagweg/Ecommerce_Platform.NET.git
```

2. Install dependencies

```bash
dotnet restore .\Ecommerce.Presentation\Api\Ecommerce.Api.csproj
dotnet tool restore
```

3. Run the Tests

```bash
dotnet test .\Ecommerce.Tests\Ecommerce.Tests.csproj
```

4. Run the Api

```bash
dotnet run --project .\Ecommerce.Presentation\Api\Ecommerce.Api.csproj
```
