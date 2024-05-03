using MediatR;
using Student.Application.Features.Commands;
using Student.Application.Interfaces;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Features.Handlers
{
  
    public class EditStudentHandlers : IRequestHandler<EditStudentCommand, string>
    {
        //1- DataContext
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructeur DI
        public EditStudentHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Ovveride Methods
        public async Task<string> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var studentId = request.student.Id;
  
            var std = await _unitOfWork._studentRepository.UpdateAsync(request.student, studentId);
            var result = "student not updated!";
            if (std != null)
            {
                result = $" student Id :{request.student.Id} updated Successfull.";
            }
            return result;

        }
        #endregion
    }
}
