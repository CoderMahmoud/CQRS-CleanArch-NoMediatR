using WebApi.Domain.Entities.Users;

namespace WebApi.Domain.Repositories;

public interface IUserRepository
{
    void Insert(User user);

    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    void Delete(User user);

    Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);

    Task SaveAsync(CancellationToken cancellationToken = default);
}