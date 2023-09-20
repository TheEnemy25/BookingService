using BookingService.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUserById(int userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { UserId = userId });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CreateUserResponseDto>> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            var createUser = await _mediator.Send(createUserCommand);

            return Ok(createUser);
        }
        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);

            return NoContent();
        }
        [HttpDelete("{userId}", Name = "DeleteUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _mediator.Send(new DeleteUserCommand() { UserId = userId });
            return NoContent();
        }
    }
}