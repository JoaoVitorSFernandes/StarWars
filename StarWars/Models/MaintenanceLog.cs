namespace StarWars.Models;

public sealed class MaintenanceLog
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Report { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Duration { get; set; }
    public Starship Starship { get; set; }

    public MaintenanceLog()
        => Duration = EndDate.Subtract(StarDate).TotalHours;
}