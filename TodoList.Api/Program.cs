using Microsoft.EntityFrameworkCore;
using Polly;
using TodoList.Api.Data;
using TodoList.Api.Extensions;
using TodoList.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TodoListDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddTransient<ITaskRepository,TaskRepository>();


var app = builder.Build();




// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoListDbContext>();
    db.Database.Migrate();
    //seed db

    //var logger = scope.ServiceProvider.GetService<ILogger<TodoListDbContextSeed>>();
    //if (logger != null)
    //    new TodoListDbContextSeed().SeedAsync(db, logger).Wait();
}


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});
app.MigrateDbContext<TodoListDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<TodoListDbContextSeed>>();
    if (logger != null)
        new TodoListDbContextSeed().SeedAsync(context, logger).Wait();
});
// Configure the HTTP request pipeline.


app.UseRouting();
app.UseAuthorization();
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
app.Run();



internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}