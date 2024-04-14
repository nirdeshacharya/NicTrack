using System.ComponentModel.DataAnnotations.Schema;

namespace NicTrackerData.Models;

public class Location
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int LocationType { get; set; }
    public string? LocationDetail { get; set; }


    public ICollection<Cravings> Cravings { get; set; }
    public ICollection<Intake> Intakes { get; set; }

}