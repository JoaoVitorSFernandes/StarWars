namespace StarWars.Models;

public sealed class MissionLog
{
    public int Id { get; set; }
    public string MissionName { get; set; }
    public string MissionStats { get; set; }
    public string Subject { get; set; }
    public string Report { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Duration { get; set; }

    public int StarshipId { get; set; }
    public Starship Starship { get; set; }
    public IList<User> Users { get; set; }

    public MissionLog(string missionName, string missionStats, string subject, string report, DateTime starDate, DateTime endDate, int starshipId)
    {
        MissionName = missionName;
        MissionStats = missionStats;
        Subject = subject;
        Report = report;
        StarDate = starDate;
        EndDate = endDate;
        Duration = SetDuration(starDate, endDate);
        StarshipId = starshipId;
    }

    public double SetDuration(DateTime starDate, DateTime endDate)
        => endDate.Subtract(starDate).TotalHours;
}