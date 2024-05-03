using MediatR;
using Student.Application.Features.Queries;
using Student.Application.Interfaces;
using Student.Domain.Entities;


namespace Student.Application.Features.Handlers
{
    public class GetStudentByHandlers : IRequestHandler<GetStudentByIdQuery, Students>
    {
        //1- object reference unit of work
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructor DI
        #region Constructor DI
        public GetStudentByHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Ovveride Methods
        public async Task<Students> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork._studentRepository.GetbyIdAsync(request.Id);
        }
        #endregion
    }
}
