using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace NicTrackerData.Models;

public class NicTracContext :DbContext
{

    public NicTracContext(DbContextOptions<NicTracContext> options)
        : base(options)
    {
        
    }
    public DbSet<Cravings> Cravingss { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Intake> Intakes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<NicotineHistory> NicotineHistorys { get; set; }
    public DbSet<NicotineType> NicotineTypes { get; set; }
    public DbSet<PersonalHealthStatus> PersonalHealthStatuss { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=localhost;Database=nicTrack;User Id=sa;Password=Letmein99;TrustServerCertificate=true");  
    }
    
}