using AutoMapper;
using Book.Application.Features.Commands;
using Book.Application.Features.Events;
using Book.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Book.Application.Features.Handlers
{
    public class CreateBookCommandHandlers : IRequestHandler<CreateBookCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookCommandHandlers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Domain.Entities.Books()
            {
             
                Title = request.Title,
                AuthorName = request.AuthorName,
                Isbn = request.Isbn,
                NoOfPage = request.NoOfPage,
                Faculty = request.Faculty,
                Prix = request.Prix,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                
            };
            await _unitOfWork.Repository<Domain.Entities.Books>().AddAsync(book);
            book.AddDomainEvent( new BookCreatedEvent(book));

            await _unitOfWork.Save(cancellationToken);

            return $"Book Id : {book.Id} Created Succesfully !";
        }
    }
}
