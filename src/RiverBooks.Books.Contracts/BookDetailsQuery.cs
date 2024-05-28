using MediatR;
using Ardalis.Result;

namespace RiverBooks.Books.Contracts;

public record BookDetailsQuery(Guid BookId) : IRequest<Result<BookDetailsResponse>>;
