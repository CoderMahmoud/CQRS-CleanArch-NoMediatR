using WebApi.Application.Abstractions.Messaging;
using WebApi.Application.Features.Users.Queries.GetUserById;
using WebApi.Domain.Entities.Users;
using WebApi.Domain.Repositories;

namespace WebApi.Application.Features.Users.Queries.GetByEmail;

public sealed class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {

        User? user = await _userRepository
                          .GetByEmailAsync(query.Email, cancellationToken);

        if (user is null)
        {
            throw new Exception($"User with Email = '{query.Email}' was not found.");
        }

        return new UserResponse(user.Id, user.UserName, user.Email);
    }
}