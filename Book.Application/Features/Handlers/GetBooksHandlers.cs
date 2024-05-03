using AutoMapper;
using AutoMapper.QueryableExtensions;
using Book.Application.DTOs;
using Book.Application.Features.Queries;
using Book.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Book.Application.Features.Handlers
{
    public class GetBooksHandlers : IRequestHandler<GetBooksQuery, List<BookDto>>
    {
        #region Object Reference
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetBooksHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Implementation Methods
        public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
          
            return await _unitOfWork.Repository<Domain.Entities.Books>().Entities
                         .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                         .ToListAsync(cancellationToken);
        }
        #endregion
    }
}
