using MediatR;
using Student.Domain.Entities;


namespace Student.Application.Features.Commands
{
    /// <summary>
    /// MediatR Command
    /// </summary>
    /// <param name="student"></param>
    public record EditStudentCommand(Students student) : IRequest<string>;
}
