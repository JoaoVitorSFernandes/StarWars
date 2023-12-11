using StarWars.Models.Exceptions;

namespace StarWars.Models;

public sealed class Starship
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int CostInCredits { get; set; }
    public string Crew { get; set; }
    public int Passengers { get; set; }
    public int CargoCapacity { get; set; }
    public string StarshipClass { get; set; }

    public User User { get; set; }
    public IList<MissionLog> MissionLogs { get; set; }
    public IList<MaintenanceLog> MaintenanceLogs { get; set; }

    public Starship(string name, string model, string manufacturer, int costInCredits, string crew, int passengers, int cargoCapacity, string starshipClass)
    {
        Name = name;
        Model = model;
        Manufacturer = manufacturer;
        CostInCredits = costInCredits;
        Crew = crew;
        Passengers = passengers;
        CargoCapacity = cargoCapacity;
        StarshipClass = starshipClass;
    }


}