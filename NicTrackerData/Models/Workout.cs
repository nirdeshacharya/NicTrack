using System.ComponentModel.DataAnnotations.Schema;

namespace NicTrackerData.Models;

public class Workout
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime WorkoutTime { get; set; }
    public string WorkoutDetail { get; set; }

}