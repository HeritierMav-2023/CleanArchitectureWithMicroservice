using Book.Application.Mappings;
using MediatR;


namespace Book.Application.Features.Commands
{
    /// <summary>
    /// MediatR Command
    /// </summary>
    /// <param name="book"></param>
    public record UpdateBookCommand : IRequest<string>
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? Isbn { get; set; }
        public int NoOfPage { get; set; } = 0;
        public string? Faculty { get; set; }
        public double Prix { get; set; }
    }

}
