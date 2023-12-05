namespace StarWars.Models;

public sealed class Starship
{
    public int Id { get; set; }
    public string name { get; set; }
    public string model { get; set; }
    public string manufacturer { get; set; }
    public int costInCredits { get; set; }
    public string crew { get; set; }
    public int passengers { get; set; }
    public int cargoCapacity { get; set; }
    public string starshipClass { get; set; }


    public User User { get; set; }
    public IList<MissionLog> MissionLogs { get; set; }
    public IList<MaintenanceLog> MaintenanceLogs { get; set; }
}