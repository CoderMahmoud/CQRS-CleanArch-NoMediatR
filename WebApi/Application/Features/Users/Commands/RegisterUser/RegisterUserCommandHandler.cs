using WebApi.Application.Abstractions.Messaging;
using WebApi.Domain.Entities.Users;
using WebApi.Domain.Repositories;

namespace WebApi.Application.Features.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = command.UserName,
            Email = command.Email
        };

        if (!await _userRepository.IsEmailUniqueAsync(command.Email))
        {
            throw new Exception("Email already in use.");
        }

        _userRepository.Insert(user);

        await _userRepository.SaveAsync(cancellationToken: cancellationToken);

        return user.Id;
    }
}