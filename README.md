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
When enforcing invariants, Steve explicitly chooses to throw exceptions in the constructor of the [`Book`](src\RiverBooks.Books\Book.cs) class. He substantiates this by saying that it should be the application layer's responsibility to validate the input to the domain model and that any bad input which has made its way to the domain layer should be treated as an exceptional case.

This is different from the way I've implemented it in the past and I can see the appeal of doing it this way. In the past when I've utilized a private constructor and a static `create` method, it did feel a bit like a chore to need to check the `Result` type to see whether it was a success or an error. That said, I'm not sure I'm ready to start throwing exceptions for this type of thing myself.