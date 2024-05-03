using AutoMapper;
using Book.Application.Features.Commands;
using Book.Application.Features.Events;
using Book.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Features.Handlers
{
    public class UpdateBookCommandHandlers : IRequestHandler<UpdateBookCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Ovveride Methods

        public async Task<string> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookUpdated = await _unitOfWork.Repository<Domain.Entities.Books>().GetByIdAsync(request.Id);
            if(bookUpdated != null)
            {
                bookUpdated.Title = request.Title;
                bookUpdated.AuthorName = request.AuthorName;
                bookUpdated.Isbn = request.Isbn;
                bookUpdated.NoOfPage = request.NoOfPage;
                bookUpdated.Faculty = request.Faculty;
                bookUpdated.Prix = request.Prix;
                bookUpdated.Title = request.Title;
                bookUpdated.UpdatedBy = 2;
                bookUpdated.UpdatedDate = DateTime.Now;

                await _unitOfWork.Repository<Domain.Entities.Books>().UpdateAsync(bookUpdated);
                bookUpdated.AddDomainEvent(new BookUpdatedEvent(bookUpdated));
                await _unitOfWork.Save(cancellationToken);

                return $"Book Id : {bookUpdated.Id} Updated !";
            }
            else
            {
                return ("Book Not Found.");
            }
        

            

            
        }
        #endregion
    }
}
