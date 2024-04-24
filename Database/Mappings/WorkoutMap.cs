using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workoutholic.Api.Database.Entities;

namespace Workoutholic.Api.Database.Mappings;

public class WorkoutMap: IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.Property(workoutTable => workoutTable.Id).IsRequired();
        builder.Property(workoutTable => workoutTable.Name).HasMaxLength(50);
    }
}