using WebApi.Application.Abstractions.Messaging;
using WebApi.Application.Features.Users.Queries.GetUserById;
using WebApi.Domain.Entities.Users;
using WebApi.Domain.Repositories;

namespace WebApi.Application.Features.Users.Queries.GetUserByUserName;

public sealed class GetUserByUserNameQueryHandler : IQueryHandler<GetUserByUserNameQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByUserNameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(GetUserByUserNameQuery query, CancellationToken cancellationToken)
    {

        User? user = await _userRepository.GetByUsernameAsync(query.UserName, cancellationToken);

        if (user == null)
        {
            throw new Exception($"User with username '{query.UserName}' was not found.");
        }

        return new UserResponse(user.Id, user.UserName, user.Email);
    }
}