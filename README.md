# CustomerManagementSystem

•	Technologies Used: .NET Core 8, SQL Server, ADO.NET, jQuery, AJAX, HTML, CSS, JavaScript.
•	Architecture: Follows a layered architecture with Controller, IService, Service, and DAL layers.
Technology Used
•	Backend: .NET Core 8, ADO.NET
•	Frontend: HTML, CSS, JavaScript, jQuery, AJAX
•	Database: SQL Server
•	Architecture: Layered Architecture
o	Controller Layer
o	Service Layer
o	Data Access Layer (DAL)


1.	Set up the project: In .NET Core and added necessary dependencies.
2.	Database Connection: The API uses ADO.NET to connect to the SQL Server database and execute stored procedures.
3.	API Endpoints:
o	GET /api/Customer: Get a list of customers.
o	GET /api/Customer/{customerCode}: Get details of a specific customer.
o	POST /api/Customer: Add a new customer.
o	PUT /api/Customer/{customerCode}: Update an existing customer.
o	DELETE /api/Customer/{customerCode}: Delete a customer.
