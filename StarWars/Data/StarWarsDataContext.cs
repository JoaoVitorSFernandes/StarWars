using Microsoft.EntityFrameworkCore;
using starWars.Data.Mapping;
using StarWars.Data.Mapping;
using StarWars.Models;

namespace StarWars.Data;

public class StarWarsDataContext : DbContext
{
    public DbSet<Starship> Starships { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<MissionLog> MissionLogs { get; set; }
    public DbSet<MaintenanceLog> MaintanenceLogs { get; set; }
    private readonly IConfiguration _configuration;

    public StarWarsDataContext(IConfiguration configuration)
        => _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("connectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new StarshipMap());
        modelBuilder.ApplyConfiguration(new MissionLogMap());
        modelBuilder.ApplyConfiguration(new MaintenanceLogMap());
    }
}