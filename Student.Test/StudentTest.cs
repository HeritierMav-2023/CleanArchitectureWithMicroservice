using Moq;
using Student.API.Controllers;
using Student.Application.Interfaces;
using Student.Test.Mock;

namespace Student.Test
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void GivenTheGetEndpoint_WhenNoParameters_ThenReturnEveryStudent()
        {
            var studentRepoMock = new StudentRepositoryMock().GetAll();

            //var controller =

        }
        //private StudentsController InstantiateController(StudentRepositoryMock? articleRepositoryMock = null)
        //{
        //    var mockArticle = StudentRepositoryMock ?? new Mock<IStudentRepository>();

        //    return new StudentsController(mockArticle.Object);
        //}
    }
}