using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext;

public sealed class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<UserGroup> UserGroups => Set<UserGroup>();
    public DbSet<UserState> UserStates => Set<UserState>();
    
    public ApplicationContext(DbContextOptions options)
        :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(user => user.Login)
            .IsUnique();
    }
}