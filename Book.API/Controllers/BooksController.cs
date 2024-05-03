using Book.Application.DTOs;
using Book.Application.Features.Commands;
using Book.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region Mediator
        private readonly IMediator _mediator;

        #endregion

        #region Constructor DI
        public BooksController(IMediator mediator, IPublisher publisher)
        {
            _mediator = mediator;
        }
        #endregion

        #region Verbs Methods

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBook()
        {
            return await _mediator.Send(new GetBooksQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookDataById(int id)
        {
            return await _mediator.Send(new GetBookByIdQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateBook(CreateBookCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateBook(int id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteBook(int id)
        {
            return await _mediator.Send(new DeleteBookCommand(id));
        }
        #endregion
    }
}
