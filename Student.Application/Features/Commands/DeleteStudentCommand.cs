using MediatR;
using Student.Domain.Entities;


namespace Student.Application.Features.Commands
{
    //public record DeleteStudentCommand(Students student) : IRequest<string>
   
    public record DeleteStudentCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DeleteStudentCommand() { }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
