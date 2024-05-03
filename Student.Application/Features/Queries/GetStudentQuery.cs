using MediatR;
using Student.Domain.Entities;

namespace Student.Application.Features.Queries
{
    /// <summary>
    /// MediatR with Queries
    /// </summary>
    public record GetStudentQuery : IRequest<IEnumerable<Students>>;
}
