namespace NicTrackerService.ViewModels;

public class PersonalHealthStatusModel
{
    public int Id { get; set; }
    public decimal? Height { get; set; }
    public decimal? Weight { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public DateTime? DateJoined { get; set; }
    public string? HomeLocation { get; set; }
    public string? OfficeLocation { get; set; }
}