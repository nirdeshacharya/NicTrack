namespace NicTrackerService.ViewModels;

public class IntakeModel
{
    public int Id { get; set; }
    public DateTime? TimeOfIntake { get; set; }
    public string? IntakeDetails { get; set; }
    public int? LocationId { get; set; }
    public int? NicotineTypeId { get; set; }
}