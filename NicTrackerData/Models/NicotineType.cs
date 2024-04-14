using System.ComponentModel.DataAnnotations.Schema;

namespace NicTrackerData.Models;

public class NicotineType
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{ get; set; }
    public string? NicotineTypeDetail { get; set; }
    public bool IsSmoke { get; set; }
    public decimal Cost { get; set; }

    public ICollection<NicotineHistory> NicotineHistories { get; set; }
}