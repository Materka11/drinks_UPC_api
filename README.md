# drinks_UPC_api
A RESTful API that manages drink-related information, including producers, brands, labels, and categories. The project is built with ASP.NET Core and uses Entity Framework for database management.

## Features
+ CRUD operations for drinks
+ Management of producers, brands, labels, and categories
+ API documentation via Swagger UI
## Requirements
+ .NET 6.0 or later
+ SQL Server with a valid connection
+ Visual Studio (optional) or another code editor supporting .NET projects
## Setup Instructions

1. #### Clone the repository:

```bash
git clone https://github.com/Materka11/drinks_UPC_api.git
cd drinks_UPC_api
```
2. #### Configure the database connection:
Update the connection string in appsettings.json or modify it directly in the code:

```json
"ConnectionStrings": {
  "DefaultConnection": "your-sql-connection-string"
}
```
3. #### Install dependencies:

```bash
dotnet restore
```
4.  #### Apply database migrations:

```bash
dotnet ef database update
```

## Running the Application
1. #### Start the API in development mode:

```bash
dotnet run
```
2. #### Access the API locally:
The application will run on:
https://localhost:5237

3. #### API documentation:
Visit https://localhost:5237/swagger to explore the API documentation through Swagger UI.

## Project Structure
+ Controllers/ – Handles incoming HTTP requests
+ Data/ – Database context configuration
+ Repository/ – Repository implementations for data management
## Technologies Used
+ ASP.NET Core – Backend framework
+ Entity Framework Core – ORM for database interactions
+ Swagger – API documentation
## Author
Developed by [Materka11](https://github.com/materka11). Feel free to open Issues for bug reports or feature suggestions.
