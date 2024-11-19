using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.DalModels;

public partial class FlightContext : DbContext
{
    public FlightContext(DbContextOptions<FlightContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightCrew> FlightCrews { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Traveling> Travelings { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(e => e.AirlineId).HasName("PK__Airlines__DC45827374FD8AC9");

            entity.Property(e => e.AirlineId).HasColumnName("AirlineID");
            entity.Property(e => e.AirlineName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ContactInformation)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Website)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flights__8A9E148E3526AFCF");

            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.AirlineId).HasColumnName("AirlineID");
            entity.Property(e => e.ArrivalAirport)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureAirport)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.FlightDuration).HasPrecision(0);

            entity.HasOne(d => d.Airline).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AirlineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Airlines_Flights");
        });

        modelBuilder.Entity<FlightCrew>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__FlightCr__123AE7B98C0DE2C9");

            entity.ToTable("FlightCrew");

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightCrews)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FlightCrew_Flights");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF97CE057C");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
            entity.Property(e => e.SeatNumber)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Flight).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Flights");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Traveling");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AEF298A9D");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleType)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Traveling>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK__Travelin__88915F909C7617CD");

            entity.ToTable("Traveling");

            entity.Property(e => e.PassengerId)
                .ValueGeneratedNever()
                .HasColumnName("PassengerID");
            entity.Property(e => e.ContactInfo)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("PK__Workers__077C8806D9AFCA46");

            entity.Property(e => e.WorkerId)
                .ValueGeneratedNever()
                .HasColumnName("WorkerID");
            entity.Property(e => e.AirlineId).HasColumnName("AirlineID");
            entity.Property(e => e.ContactInfo)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DateOfEmployment).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Airline).WithMany(p => p.Workers)
                .HasForeignKey(d => d.AirlineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Airlines_Workers");

            entity.HasOne(d => d.Role).WithMany(p => p.Workers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Workers_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
