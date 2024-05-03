using MediatR;
using Student.Application.Features.Commands;
using Student.Application.Interfaces;

namespace Student.Application.Features.Handlers
{
    public class DeleteStudentHandlers : IRequestHandler<DeleteStudentCommand, string>
    {
        //1- DataContext
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructor DI
        public DeleteStudentHandlers(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }
        #region Ovveride Methods
     
        public async Task<string> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = "student not Deleted !";
            var student = await _unitOfWork._studentRepository.GetbyIdAsync(request.Id);
            if (student != null)
            {
                await _unitOfWork._studentRepository.DeleteAsync(student);
                result = $" student Id :{student.Id} Deleted Successfull.";
            }
            return result;
        }
        #endregion
    }
}
