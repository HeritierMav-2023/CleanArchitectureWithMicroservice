using Book.Domain;


namespace Book.Application.Features.Events
{
    public class BookUpdatedEvent : BaseEvent
    {
        public Domain.Entities.Books Book { get; }

        public BookUpdatedEvent(Domain.Entities.Books book)
        {
            Book = book;
        }
    }
}
