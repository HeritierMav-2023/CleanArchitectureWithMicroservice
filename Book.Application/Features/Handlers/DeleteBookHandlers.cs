using AutoMapper;
using Book.Application.Features.Commands;
using Book.Application.Features.Events;
using Book.Application.Interfaces;
using MediatR;


namespace Book.Application.Features.Handlers
{
    public class DeleteBookHandlers : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Ovveride Methods
        public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Repository<Domain.Entities.Books>().GetByIdAsync(request.Id);
            if (book != null)
            {
                await _unitOfWork.Repository<Domain.Entities.Books>().DeleteAsync(book);
                book.AddDomainEvent(new BookDeletedEvent(book));

                await _unitOfWork.Save(cancellationToken);

                return $"Book : {request.Id} Deleted Succesfully !";
            }
            else
                return $"Book Not Found.";
        }
       
        #endregion
    }
}
