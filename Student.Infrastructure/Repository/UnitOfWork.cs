using Student.Application.Interfaces;


namespace Student.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //1-Déclaration d'objets repository
        public IStudentRepository _studentRepository { get; }

        //2-Constructeur DI
        public UnitOfWork(IStudentRepository StudentRepository)
        {
            _studentRepository = StudentRepository;
        }

      
    }
}
