using AutoMapper;
using BookingService.API.User.Requests;
using BookingService.API.User.Responses;
using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using Microsoft.AspNetCore.Mvc;



namespace BookingService.API
{
    [Route("api/users")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var userDto = _mapper.Map<UserDto>(createUserRequest);
            var createdUser = await _userService.CreateUser(userDto);
            var userResponse = _mapper.Map<UserResponse>(createdUser);
            return Ok(userResponse);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var userDto = await _userService.GetUserById(userId);
            var userResponse = _mapper.Map<UserResponse>(userDto);
            return Ok(userResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            var userDto = _mapper.Map<UserDto>(updateUserRequest);
            await _userService.UpdateUser(userDto);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }
    }
}

