using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities.Users;
using WebApi.Domain.Repositories;

namespace WebApi.Infrastructure;

public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly InMemoryDbContext _context;

    public InMemoryUserRepository(InMemoryDbContext dbContext)
    {
        _context = dbContext;
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users
                    .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users
                    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _context.Users
                    .FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
    }

    public void Insert(User user)
    {
        _context.Users.Add(user);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
    {
        return !await _context.Users
                     .AnyAsync(user => user.Email == email, cancellationToken);
    }

    public Task SaveAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}