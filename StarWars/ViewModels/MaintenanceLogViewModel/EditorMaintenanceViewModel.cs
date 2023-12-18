namespace StarWars.ViewModels.MaintenanceLogViewModel;

public class EditorMaintenanceViewModel
{
    public string Subject { get; set; }
    public string Report { get; set; }
    public string MaintenanceStatus { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public int StarshipId { get; set; }
}