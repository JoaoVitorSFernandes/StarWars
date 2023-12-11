using StarWars.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMemoryCache();
builder.Services.AddDbContext<StarWarsDataContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
