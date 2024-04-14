using System.ComponentModel.DataAnnotations.Schema;

namespace NicTrackerData.Models;

public class Intake
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime TimeOfIntake { get; set; }
    public string? IntakeDetails { get; set; }
    public int LocationId { get; set; }
    public int NicotineTypeId { get; set; }


    public Location Location { get; set; }
    public NicotineType NicotineType { get; set; }
}