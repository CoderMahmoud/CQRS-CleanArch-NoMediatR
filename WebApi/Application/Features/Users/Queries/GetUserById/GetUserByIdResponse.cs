namespace WebApi.Application.Features.Users.Queries.GetUserById;

public sealed record UserResponse(Guid UserId, string UserName, string Email);
