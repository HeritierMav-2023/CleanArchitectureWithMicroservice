using MediatR;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Features.Commands;
using Student.Application.Features.Queries;
using Student.Domain.Entities;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        #region Attributs
        private readonly ISender _sender;

        #endregion

        #region Constructeur DI
        public StudentsController(ISender sender)
        {
            _sender = sender;
 
        }
        #endregion

        #region Verbs Methods
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetStudentQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetStudentById")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            var product = await _sender.Send(new GetStudentByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(Students student)
        {
            var productToReturn = await _sender.Send(new AddStudentCommand(student));

            return Ok(productToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Students>> EditProduct(int id,Students student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var productToReturn = await _sender.Send(new AddStudentCommand(student));
   
            return Ok(productToReturn);
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int Id)
        {
            if (Id == 0)
                return BadRequest();
            var productToDeleted = await _sender.Send(new DeleteStudentCommand(Id));
            return Ok(productToDeleted);
        }
        #endregion
    }
}
