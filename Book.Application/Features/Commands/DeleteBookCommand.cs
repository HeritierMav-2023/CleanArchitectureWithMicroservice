using Book.Application.Mappings;
using MediatR;



namespace Book.Application.Features.Commands
{
   
    public record DeleteBookCommand : IRequest<string>, IMapFrom<Domain.Entities.Books>
    {
        public int Id { get; set; }

        public DeleteBookCommand()
        {

        }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
