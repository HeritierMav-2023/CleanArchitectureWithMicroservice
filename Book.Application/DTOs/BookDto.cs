using Book.Application.Mappings;



namespace Book.Application.DTOs
{
    public class BookDto : IMapFrom<Domain.Entities.Books>
    {
        public int Id { get; set; }
        public string Title { get; init; }
        public string AuthorName { get; init; }
        public string Isbn { get; init; }
        public int NoOfPage { get; init; }
        public string Faculty { get; init; }
        public double Prix { get; init; }
    }
}
