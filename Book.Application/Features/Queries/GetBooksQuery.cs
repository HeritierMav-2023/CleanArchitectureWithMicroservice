using Book.Application.DTOs;
using MediatR;

namespace Book.Application.Features.Queries
{
    public record GetBooksQuery : IRequest<List<BookDto>>;
}
