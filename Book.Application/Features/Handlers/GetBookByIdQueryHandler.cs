using AutoMapper;
using Book.Application.DTOs;
using Book.Application.Features.Queries;
using Book.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Features.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        #region Propriétes

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructeur
        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Ovverides Methods
        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Domain.Entities.Books>().GetByIdAsync(request.Id);
            var book = _mapper.Map<BookDto>(entity);
            if (book is null)
                return null;
            return book;
        }
        #endregion
    }
}
