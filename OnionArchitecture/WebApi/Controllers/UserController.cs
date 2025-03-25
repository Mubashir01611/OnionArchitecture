using Application.Features.UserFeatures.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]

    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            await Mediator.Send(command);
            return Ok("User Added Successfully");
        }
    }
}
