using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Abstractions.Messaging;
using WebApi.Application.Features.Users.Commands.DeleteUser;
using WebApi.Application.Features.Users.Commands.RegisterUser;
using WebApi.Application.Features.Users.Queries.GetByEmail;
using WebApi.Application.Features.Users.Queries.GetUserById;
using WebApi.Application.Features.Users.Queries.GetUserByUserName;

namespace WebApi.Controllers.UserController;

[Route("api/users")]
[ApiController]
public sealed class UserController : ControllerBase
{
    private readonly ICommandHandler<RegisterUserCommand, Guid> _registerUserCommand;
    private readonly IQueryHandler<GetUserByIdQuery, UserResponse> _getUserByIdQuery;
    private readonly IQueryHandler<GetUserByUserNameQuery, UserResponse> _getUserByUserNameQuery;
    private readonly IQueryHandler<GetUserByEmailQuery, UserResponse> _getUserByEmailQuery;
    private readonly ICommandHandler<DeleteUserCommand> _deleteUserCommand;

    public UserController(
        ICommandHandler<RegisterUserCommand, Guid> registerUserCommandHandler,
        IQueryHandler<GetUserByIdQuery, UserResponse> getUserByIdQueryHandler,
        IQueryHandler<GetUserByUserNameQuery, UserResponse> getUserByUserNameQueryHandler,
        ICommandHandler<DeleteUserCommand> deleteUserCommandHandler,
        IQueryHandler<GetUserByEmailQuery, UserResponse> getUserByEmailQuery)
    {
        _registerUserCommand = registerUserCommandHandler;
        _getUserByIdQuery = getUserByIdQueryHandler;
        _getUserByUserNameQuery = getUserByUserNameQueryHandler;
        _deleteUserCommand = deleteUserCommandHandler;
        _getUserByEmailQuery = getUserByEmailQuery;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
    {
        try
        {

            var createdUserId = await _registerUserCommand
                                      .Handle(command, cancellationToken);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUserId }, createdUserId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getUserByIdQuery
                                 .Handle(new GetUserByIdQuery(id), cancellationToken);

            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("by-username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByUserName(string username, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getUserByUserNameQuery
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
            await _deleteUserCommand
                            .Handle(new DeleteUserCommand(id), cancellationToken);

            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("by-email/{email}"), ActionName("getByEmail")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByEmail(string email, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getUserByEmailQuery
                                .Handle(new GetUserByEmailQuery(email), cancellationToken);

            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }
}