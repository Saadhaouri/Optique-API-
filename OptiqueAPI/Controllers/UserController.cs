using AutoMapper;
using Core.App.Dto;
using Core.App.IServices;
using Microsoft.AspNetCore.Mvc;
using OptiqueAPI.ViewModels;

[Route("api/[controller]")]
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

    [HttpGet]
    public IActionResult GetUsers()
    {
        var userDtos = _userService.GetUsers();
        var userViewModels = _mapper.Map<IEnumerable<UserViewModel>>(userDtos);
        return Ok(userViewModels);
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserById(string userId)
    {
        var userDto = _userService.GetUserById(userId);
        if (userDto == null)
        {
            return NotFound();
        }
        var userViewModel = _mapper.Map<UserViewModel>(userDto);
        return Ok(userViewModel);
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] UserViewModel userViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var userDto = _mapper.Map<UserDto>(userViewModel);
        _userService.AddUser(userDto);
        return Ok("User  added successfully");
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser(string userId, [FromBody] UserViewModel userViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingUserDto = _userService.GetUserById(userId);
        if (existingUserDto == null)
        {
            return NotFound();
        }
        _mapper.Map(userViewModel, existingUserDto);
        _userService.UpdateUser(existingUserDto);
        return NoContent();
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(string userId)
    {
        var existingUserDto = _userService.GetUserById(userId);
        if (existingUserDto == null)
        {
            return NotFound();
        }
        _userService.DeleteUser(userId);
        return NoContent();
    }
}