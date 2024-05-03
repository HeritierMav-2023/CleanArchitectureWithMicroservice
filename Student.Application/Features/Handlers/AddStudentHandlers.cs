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
    public class AddStudentHandlers : IRequestHandler<AddStudentCommand, string>
    {
        //1- DataContext
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructeur DI
        public AddStudentHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        #region Ovveride Methods
        public async Task<string> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork._studentRepository.CreateAsync(request.student);
            var result = "student Not created!";
            if(student != null)
            {
                result= $" student Id : {request.student.Id} created Successfull.";
            }
            return result;
        }

        #endregion
    }
}
