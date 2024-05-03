using MediatR;
using Student.Domain.Entities;


namespace Student.Application.Features.Queries
{
    /// <summary>
    /// MediatR with Queries
    /// </summary>
    /// <param name="Id"></param>
    public record GetStudentByIdQuery(int Id) : IRequest<Students>;
}
