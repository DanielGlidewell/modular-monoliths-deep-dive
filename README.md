# Modular Monoliths - Getting Started 
This repo represents my work following along with Steve Smith's course at [Dometrain](https://www.dometrain.com).

I will update this readme with my notes as I proceed through the course.

## April 27th, 2024
### Project Setup
The module itself is responsible for defining the endpoints for consuming its services.

We are being careful not to expose the wiring up of the implementation of our BookService interface to consumers. 

### List Books Endpoint
Added [fast endpoints](https://fast-endpoints.com/) package to both projects. Steve mentions that this allows us to use the Request-Endpoint-Response (REPR) pattern.

Refactored to use the REPR pattern exclusively

### Book Domain
#### Invariants
When enforcing invariants, Steve explicitly chooses to throw exceptions in the constructor of the [`Book`](src\RiverBooks.Books\Book.cs) class. He substantiates this by saying that it should be the application layer's responsibility to validate the input to the domain model and that any bad input which has made its way to the domain layer should be treated as an exceptional case.

This is different from the way I've implemented it in the past and I can see the appeal of doing it this way. In the past when I've utilized a private constructor and a static `create` method, it did feel a bit like a chore to need to check the `Result` type to see whether it was a success or an error. That said, I'm not sure I'm ready to start throwing exceptions for this type of thing myself.

### Book Repository
Steve is choosing to implement a separate `SaveChangesAsync()` method on the [repository](src\RiverBooks.Books\EfBookRepository.cs). For methods like `AddAsync` and `DeleteAsync`, they will be interacting with the `BookDbContext`, but they will also simply be returning a `Task.CompletedTask`. I wonder why he's chosen to do things like this and what the alternatives would be. He mentioned "unit of work" and I'm still vague on that concept. I wonder if this gives us more control in the `BookService` for when we'd like to actually fire off those changes to the database.

### Db Migrations
We set up a [`BookDbContext`](src\RiverBooks.Books\BookDbContext.cs) in which we overrode the `OnModelCreating` method so that we could specify a default schema `books` and that we have additional specifications for the various entities of this context elsewhere in the assembly that it should look for and apply.

The [`BookConfiguration`](src\RiverBooks.Books\BookConfiguration.cs) specfies how the data type table's columns should be constrained and it also generates some sample data.

Steve mentions that generally migrations are typically done in the startup application. In our case, that's the Web project.

In order to add migrations to the project, we need to install some tooling by running this in the terminal: `dotnet tool install --global dotnet-ef`. 

Additionally, the project responsible for running the migrations needs to have a reference to the `Microsoft.EntityFrameworkCore.Design` package.

Here's an example of the command used to create a new migration:
>`dotnet ef migrations add Initial -c BookDbContext -p ..\RiverBooks.Books\ -s .\RiverBooks.Web.csproj -o Data/Migrations`
