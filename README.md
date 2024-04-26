# ADO.NET Employee CRUD Program

## How to Run the Program

- Clone the Project
- Make Sure to Install SQL Server 2022 and SQL Server Management Studio
- Run the Query in SQL Server Management Studio to create the Database

```csharp
USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'Election'
)
CREATE DATABASE [Election]
GO
```

- Then Create a table called `vote` in the `Employee` Database
- Then Run the Program in Visual Studio 2022
- Enjoy!
  
Author: Sarthak Roy
