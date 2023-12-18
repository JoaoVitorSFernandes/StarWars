namespace StarWars.ViewModels.MissionLogViewModel;

public class EditorMissionLogViewModel
{
    public string MissionName { get; set; }
    public string MissionStats { get; set; }
    public string Subject { get; set; }
    public string Report { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public int StarshipId { get; set; }
}