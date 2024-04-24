using Microsoft.EntityFrameworkCore;
using Workoutholic.Api.Database;
using Workoutholic.Api.Database.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(
    opt => 
        opt.UseSqlServer(builder.Configuration.GetConnectionString("WorkoutholicDb")).EnableSensitiveDataLogging()
);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var workouts = new List<Workout>();

app.MapPost("/workout", (Workout workout) =>
{
    workouts.Add(workout);
});

app.MapGet("/workout", () =>
{
    return workouts;
});

app.MapPut("workout/{id}", (Guid id, Workout putData) =>
{
    var workoutIndex = workouts.FindIndex((workout) => workout.Id == id);
    workouts[workoutIndex] = putData;
});

app.MapDelete("workout/{id}", (Guid id) =>
{
    var workoutIndex = workouts.FindIndex((workout) => workout.Id == id);
    workouts.RemoveAt(workoutIndex);
});

app.Run();
