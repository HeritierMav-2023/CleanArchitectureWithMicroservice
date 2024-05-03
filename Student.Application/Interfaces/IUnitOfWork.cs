using System;


namespace Student.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository _studentRepository { get; }
    }
}
