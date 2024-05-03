using Book.Application.Interfaces;


namespace Book.Persitence.Repositories
{
    public class BookRepository : IBookRepository
    {
        //1- decelaration repo
        private readonly IGenericRepository<Domain.Entities.Books> _repository;

        //2- constructor DI
        public BookRepository(IGenericRepository<Domain.Entities.Books> repository)
        {
            _repository = repository;
        }
    }
}
