using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities.Users;

namespace WebApi.Infrastructure;

public class InMemoryDbContext : DbContext
{
    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
        : base(options)
    { }
    public DbSet<User> Users => Set<User>();
}