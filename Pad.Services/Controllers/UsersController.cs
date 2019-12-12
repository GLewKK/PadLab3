using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Pad.Domain.Entities;
using Pad.Representation.Abstractions;

namespace Pad.Services.Controllers
{
    [Route("users/api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserConfigurationRepository _repository;

        public UsersController(IUserConfigurationRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddUserData([FromBody]UserConfiguration model)
        {
            _repository.Add(model);

            return Ok();
        }
    }
}