using WebApi.Domain.Entities.Users;

namespace WebApi.Domain.Repositories;

public interface IUserRepository
{
    void Insert(User user);

    Task<User?> Get(Guid id);

    Task<User?> Get(string username);

    void Delete(User user);

    Task SaveAsync(CancellationToken cancellationToken = default);
}