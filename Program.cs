using Workoutholic.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapPut("workout/{id}", (string id, Workout putData) =>
{
    var workoutIndex = workouts.FindIndex((workout) => workout.Id == id);
    workouts[workoutIndex] = putData;
});

app.MapDelete("workout/{id}", (string id) =>
{
    var workoutIndex = workouts.FindIndex((workout) => workout.Id == id);
    workouts.RemoveAt(workoutIndex);
});

app.Run();
