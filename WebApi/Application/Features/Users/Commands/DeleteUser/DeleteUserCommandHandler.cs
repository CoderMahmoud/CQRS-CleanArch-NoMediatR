using WebApi.Application.Abstractions.Messaging;
using WebApi.Domain.Entities.Users;
using WebApi.Domain.Repositories;

namespace WebApi.Application.Features.Users.Commands.DeleteUser;

public sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {

        User? user = await _userRepository.Get(command.UserId);

        if (user == null)
        {
            throw new Exception($"User with the ID '{command.UserId}' could not be found.");
        }

        _userRepository.Delete(user);

        await _userRepository.SaveAsync(cancellationToken: cancellationToken);
    }
}
