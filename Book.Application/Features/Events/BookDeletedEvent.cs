using Book.Domain;


namespace Book.Application.Features.Events
{
    public class BookDeletedEvent : BaseEvent
    {
        public Domain.Entities.Books Book { get; }

        public BookDeletedEvent(Domain.Entities.Books book)
        {
            Book = book;
        }
    }
}
