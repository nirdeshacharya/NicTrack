using System.ComponentModel.DataAnnotations.Schema;

namespace NicTrackerData.Models;

public class NicotineHistory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int NicotineTypeId { get; set; }
    public int IntakePerDay { get; set; }

    public NicotineType NicotineType { get; set; }
}