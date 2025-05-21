using WebApi.Application.Abstractions.Messaging;
using WebApi.Application.Features.Users.Queries.GetUserById;

namespace WebApi.Application.Features.Users.Queries.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;