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

    public async Task<User?> Get(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> Get(string username)
    {
        return await _context.Users
                    .FirstOrDefaultAsync(x => x.UserName == username);
    }

    public void Insert(User user)
    {
        _context.Users.Add(user);
    }

    public Task SaveAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}