using WebApi.Application.Abstractions.Messaging;

namespace WebApi.Application.Features.Users.Commands.RegisterUser;

public sealed record RegisterUserCommand(string UserName, string Email) : ICommand<Guid>;