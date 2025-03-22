using System.ComponentModel.DataAnnotations.Schema;

namespace NicTrackerData.Models;


public enum CravingSeverity
{
    A, B, C, D, F
}
public class Cravings
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime TimeOfCraving { get; set; }
    public string? CravingDetails { get; set; }
    public CravingSeverity CravingSeverity { get; set; }
    public int LocationId { get; set; }

    public int Intensity { get; set; }

    
    public Location? Location { get; set; }


}