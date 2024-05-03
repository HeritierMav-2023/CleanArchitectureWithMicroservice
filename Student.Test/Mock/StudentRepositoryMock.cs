using Moq;
using Student.Application.Interfaces;
using Student.Test.Mock.Model;


namespace Student.Test.Mock
{
    public class StudentRepositoryMock : Mock<IStudentRepository>
    {
        public StudentRepositoryMock GetAll() 
        { 
            Setup(x=>x.GetAllAsync())
                .Returns(new StudentMock().GetAll())
                .Verifiable();

            return this;
        }

        public StudentRepositoryMock GetById()
        {
            Setup(x=>x.GetbyIdAsync(It.IsAny<int>()))
                .Returns(new StudentMock().Get())
                .Verifiable();
            return this;
        }

    }
}
