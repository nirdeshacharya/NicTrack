﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NicTrackerData.Models;

#nullable disable

namespace NicTrackerData.Migrations
{
    [DbContext(typeof(NicTracContext))]
    partial class NicTracContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NicTrackerData.Models.Cravings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CravingDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CravingSeverity")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfCravings")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Cravingss");
                });

            modelBuilder.Entity("NicTrackerData.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FinalIntake")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("NicTrackerData.Models.Intake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IntakeDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("NicotineTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfIntake")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("NicotineTypeId");

                    b.ToTable("Intakes");
                });

            modelBuilder.Entity("NicTrackerData.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LocationDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("NicTrackerData.Models.NicotineHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IntakePerDay")
                        .HasColumnType("int");

                    b.Property<int>("NicotineTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NicotineTypeId");

                    b.ToTable("NicotineHistorys");
                });

            modelBuilder.Entity("NicTrackerData.Models.NicotineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsSmoke")
                        .HasColumnType("bit");

                    b.Property<string>("NicotineTypeDetail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NicotineTypes");
                });

            modelBuilder.Entity("NicTrackerData.Models.PersonalHealthStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HomeLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PersonalHealthStatuss");
                });

            modelBuilder.Entity("NicTrackerData.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("WorkoutDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WorkoutTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("NicTrackerData.Models.Cravings", b =>
                {
                    b.HasOne("NicTrackerData.Models.Location", "Location")
                        .WithMany("Cravings")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("NicTrackerData.Models.Intake", b =>
                {
                    b.HasOne("NicTrackerData.Models.Location", "Location")
                        .WithMany("Intakes")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NicTrackerData.Models.NicotineType", "NicotineType")
                        .WithMany()
                        .HasForeignKey("NicotineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("NicotineType");
                });

            modelBuilder.Entity("NicTrackerData.Models.NicotineHistory", b =>
                {
                    b.HasOne("NicTrackerData.Models.NicotineType", "NicotineType")
                        .WithMany("NicotineHistories")
                        .HasForeignKey("NicotineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NicotineType");
                });

            modelBuilder.Entity("NicTrackerData.Models.Location", b =>
                {
                    b.Navigation("Cravings");

                    b.Navigation("Intakes");
                });

            modelBuilder.Entity("NicTrackerData.Models.NicotineType", b =>
                {
                    b.Navigation("NicotineHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
