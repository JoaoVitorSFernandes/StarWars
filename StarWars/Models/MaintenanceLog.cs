namespace StarWars.Models;

public sealed class MaintenanceLog
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Report { get; set; }
    public string MaintenanceStatus { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Duration { get; set; }

    public int StarshipId { get; set; }
    public Starship Starship { get; set; }

    public MaintenanceLog()
        => Duration = EndDate.Subtract(StarDate).TotalHours;

    public MaintenanceLog(string subject, string report, string maintenanceStatus, DateTime starDate, DateTime endDate, int starshipId)
    {
        Subject = subject;
        Report = report;
        MaintenanceStatus = maintenanceStatus;
        StarDate = starDate;
        EndDate = endDate;
        Duration = SetDuration(starDate, endDate);
        StarshipId = starshipId;
    }

    public double SetDuration(DateTime starDate, DateTime endDate)
        => endDate.Subtract(starDate).TotalHours;

}