using WebApi.Application.Abstractions.Messaging;

namespace WebApi.Application.Features.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;