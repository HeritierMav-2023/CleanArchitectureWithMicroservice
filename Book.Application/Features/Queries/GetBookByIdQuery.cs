using Book.Application.DTOs;
using MediatR;

namespace Book.Application.Features.Queries
{
    public record GetBookByIdQuery : IRequest<BookDto>
    {
        public int Id { get; set; }

        public GetBookByIdQuery()
        {

        }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
