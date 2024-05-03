using MediatR;
using Student.Application.Features.Queries;
using Student.Application.Interfaces;
using Student.Domain.Entities;

namespace Student.Application.Features.Handlers
{
    public class GetStudentHandlers : IRequestHandler<GetStudentQuery, IEnumerable<Students>>
    {
        //1- DataContext
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructor DI
        public GetStudentHandlers(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }

        //3-Ovveride Methods
        public async Task<IEnumerable<Students>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork._studentRepository.GetAllAsync();
        }
      
    }
}
