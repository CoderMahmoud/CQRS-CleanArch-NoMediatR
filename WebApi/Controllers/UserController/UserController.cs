using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.Users.Commands.DeleteUser;
using WebApi.Application.Features.Users.Commands.RegisterUser;
using WebApi.Application.Features.Users.Queries.GetUserById;
using WebApi.Application.Features.Users.Queries.GetUserByUserName;

namespace WebApi.Controllers.UserController;

[Route("api/users")]
[ApiController]
public sealed class UserController : ControllerBase
{
    private readonly RegisterUserCommandHandler _registerUserCommandHandler;
    private readonly GetUserByIdQueryHandler _getUserByIdQueryHandler;
    private readonly GetUserByUserNameQueryHandler _getUserByUserNameQueryHandler;
    private readonly DeleteUserCommandHandler _deleteUserCommandHandler;
    public UserController(RegisterUserCommandHandler registerUserCommandHandler, GetUserByIdQueryHandler getUserByIdQueryHandler, GetUserByUserNameQueryHandler userByUserNameQueryHandler, DeleteUserCommandHandler deleteUserCommandHandler)
    {
        _registerUserCommandHandler = registerUserCommandHandler;
        _getUserByIdQueryHandler = getUserByIdQueryHandler;
        _getUserByUserNameQueryHandler = userByUserNameQueryHandler;
        _deleteUserCommandHandler = deleteUserCommandHandler;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var createdUserId = await _registerUserCommandHandler
                                  .Handle(command, cancellationToken);

        return CreatedAtAction(nameof(GetUserById), new { id = createdUserId }, createdUserId);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getUserByIdQueryHandler
                                 .Handle(new GetUserByIdQuery(id), cancellationToken);

            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByUserName(string username, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getUserByUserNameQueryHandler
                          .Handle(new GetUserByUserNameQuery(username), cancellationToken);

            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _deleteUserCommandHandler
                            .Handle(new DeleteUserCommand(id), cancellationToken);

            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}