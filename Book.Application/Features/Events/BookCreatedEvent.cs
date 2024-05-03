using Book.Domain;


namespace Book.Application.Features.Events
{
    public class BookCreatedEvent : BaseEvent
    {
        public Domain.Entities.Books Book { get; }

        public BookCreatedEvent(Domain.Entities.Books book)
        {
            Book = book;
        }
    }
}
