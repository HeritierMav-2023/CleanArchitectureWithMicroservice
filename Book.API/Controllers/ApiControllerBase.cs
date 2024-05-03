
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract  class ApiControllerBase : ControllerBase
    {
    }
}
