namespace StarWars.Models;

public sealed class MissionLog
{
    public int Id { get; set; }
    public string MissionName { get; set; }
    public string Subject { get; set; }
    public string Report { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Duration { get; set; }

    public Starship Starship { get; set; }
    public IList<User> Users { get; set; }

    public MissionLog()
        => Duration = EndDate.Subtract(StarDate).TotalDays;
}