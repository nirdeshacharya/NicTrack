namespace NicTrackerService.ViewModels;

public class CravingsModel
{
    public int Id { get; set; }
    public DateTime? TimeOfCravings { get; set; }
    public string? CravingDetails { get; set; }
    public int? LocationId { get; set; }
}