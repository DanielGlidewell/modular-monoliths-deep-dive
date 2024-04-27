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