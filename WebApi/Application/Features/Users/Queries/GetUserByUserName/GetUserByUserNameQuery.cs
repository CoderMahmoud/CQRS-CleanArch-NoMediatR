using WebApi.Application.Abstractions.Messaging;
using WebApi.Application.Features.Users.Queries.GetUserById;

namespace WebApi.Application.Features.Users.Queries.GetUserByUserName;

public sealed record GetUserByUserNameQuery(string UserName) : IQuery<UserResponse>;