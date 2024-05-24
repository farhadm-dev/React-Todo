

using ToDoApp.Server.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext <DataContext> ();
builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
