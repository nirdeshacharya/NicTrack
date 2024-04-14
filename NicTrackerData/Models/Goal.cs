using System.ComponentModel.DataAnnotations.Schema;

namespace NicTrackerData.Models;

public class Goal
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime FinalIntake { get; set; }
    }