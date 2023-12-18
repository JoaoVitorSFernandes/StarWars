using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StarWars.Data;
using StarWars.Interfaces.Base;
using StarWars.Interfaces.MaintenanceLogInterfaces;
using StarWars.Interfaces.MissionLogInterfaces;
using StarWars.Interfaces.StarshipsInterfaces;
using StarWars.Interfaces.StarshipsSaleInterfaces;
using StarWars.Interfaces.UserInterfaces;
using StarWars.Models;
using StarWars.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JwtConfiguration:JwtKey"));
    builder.Services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", options =>
    {
        options.LoginPath = "v1/user/signin";
        options.AccessDeniedPath = "v1/user/NotFound";
    });
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddOptions();
    builder.Services.AddMemoryCache();

    builder
        .Services
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApp", Version = "v1" });
    });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<StarWarsDataContext>();
    
    builder.Services.AddTransient<StarWarsDataContext>();
    builder.Services.AddTransient<TokenService>();
    builder.Services.AddTransient<EmailService>();

    builder.Services.AddScoped<IUserManager, UserManager>();
    builder.Services.AddScoped<IStarshipManager, StarshipManager>();
    builder.Services.AddScoped<IStarshipSaleManager, StarshipSaleManager>();
    builder.Services.AddScoped<IMissionLogManager, MissionLogManager>();
    builder.Services.AddScoped<IMaintenanceLogManager , MaintenanceLogManager>();
}