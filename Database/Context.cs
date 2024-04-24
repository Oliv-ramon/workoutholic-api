using Microsoft.EntityFrameworkCore;
using Workoutholic.Api.Database.Entities;
using Workoutholic.Api.Database.Mappings;

namespace Workoutholic.Api.Database;

internal class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Workout> Workouts => Set<Workout>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkoutMap());
        base.OnModelCreating(modelBuilder);
    }
}
