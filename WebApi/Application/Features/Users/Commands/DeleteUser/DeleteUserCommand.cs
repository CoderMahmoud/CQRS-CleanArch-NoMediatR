using WebApi.Application.Abstractions.Messaging;

namespace WebApi.Application.Features.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid UserId) : ICommand;
