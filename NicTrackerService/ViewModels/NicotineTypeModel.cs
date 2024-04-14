namespace NicTrackerService.ViewModels;

public class NicotineTypeModel
{
    public int Id{ get; set; }
    public string? NicotineTypeDetail { get; set; }
    public bool? IsSmoke { get; set; }
    public decimal? Cost { get; set; }
}