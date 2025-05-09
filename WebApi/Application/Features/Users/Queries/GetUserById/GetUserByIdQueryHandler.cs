using WebApi.Application.Abstractions.Messaging;
using WebApi.Domain.Entities.Users;
using WebApi.Domain.Repositories;

namespace WebApi.Application.Features.Users.Queries.GetUserById;

public sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {

        User? user = await _userRepository.Get(query.UserId);

        if (user == null)
        {
            throw new Exception($"User with the ID '{query.UserId}' could not be found.");
        }

        return new UserResponse(user.Id, user.UserName, user.Email);
    }
}