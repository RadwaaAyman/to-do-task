ToDo API - CRUD Instructions
This project provides a basic CRUD implementation for managing ToDo items using ASP.NET Core Web API.

Prerequisites
.NET 8 SDK 
SQL Server (DB provider)
Visual Studio 2022+ 

Step 1: Update the Database
Before running the API, make sure your database is up to date with the latest migrations.

In the terminal, run:
"dotnet ef database update --project ToDo.Infrastructure"
 OR 
 In the packe manager console , run :
 "Update-Database"


 Step 2: Run the API
To start the API and test the CRUD operations:
"dotnet run --project ToDo.API"

From the Swagger UI, you can:

GET /api/todo – List all ToDo items

GET /api/todo/{id} – Get a specific ToDo item

POST /api/todo – Create a new ToDo item

PUT /api/todo/{id} – Update an existing ToDo item

DELETE /api/todo/{id} – Delete a ToDo item

Project Structure : 

ToDo.API: Main API project

ToDo.Application: Application logic (services, DTOs, Contracts)

ToDo.Domain: Domain entities , enums

ToDo.Core: Shared entities , Result pattern 

ToDo.Infrastructure: EF Core migrations and DB context , Configurations

ToDo.Test : Unit test for project 

 Example ToDo Payload:
 {
  "title": "Finish documentation",
  "description": "Write README instructions for the ToDo API",
  "dueDate": "2025-06-01T00:00:00",
  "Priority": "Medium",
  "Status" : "Pending"
}
