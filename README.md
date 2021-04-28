# CustomerDetailsService

The Customer Details API Service is a simple tool which demonstrates CRUD functionality using Entity Framework as it object-database mapper.

To run this project locally, a SQL DB will be needed and the connection string for the database will need to be added to the appsettings.json file as so:

`"ConnectionStrings": {
            "SqlDatabase": "local SQL database connection string"
         }
`

Once a connection is established you are now in a position to run the migration and seed the database with the two default customers supplied in the CustomerContext.cs file. Simply open the Package Manager Console window and run `Update-database`.

Once the databse is updated you can simply run the project and you will be presented with the Swagger UI showing each endpoint. This is a simple view of how you can invoke each endpoint.

Another very plain and simple view has also been created using React and this page can be accessed by visiting https://localhost:{portnumber}/customers. Here you are presented with a single page which simple allows you
to perform each CRUD process and view customers in a plain table. This UI is very simple and over time styling and better logic will most definitely need to be applied as currently it consists of one single monolithic component which is very ugly. This was simply to help others who have no knowledge of swagger.

This Service overall demonstrates the use of:

* A .Net Core Web API with React
* Repository Pattern
* Strategy Pattern
* React class component
* Swagger
* Xunit and Moq

Tests against this project are currently very simple and given extra time should be vastly improved by seeding test data to the database allowing you to assert against them.
