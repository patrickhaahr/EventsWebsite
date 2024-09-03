using EventsWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<EventCategoryMapping> EventCategoryMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
        .HasOne(ur => ur.User)
        .WithMany(u => u.UserRoles)
        .HasForeignKey(ur => ur.UserID)
        .OnDelete(DeleteBehavior.NoAction);  // Adjust based on your needs

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Event)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(ur => ur.EventID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.City)
            .WithMany(c => c.Events)
            .HasForeignKey(e => e.CityName)
            .HasPrincipalKey(c => c.CityName);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany(u => u.Events)
            .HasForeignKey(e => e.OrganizerID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete for Events when the Organizer is deleted

        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Event)
            .WithMany(e => e.Registrations)
            .HasForeignKey(r => r.EventID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete for Registrations when the Event is deleted

        modelBuilder.Entity<Registration>()
            .HasOne(r => r.User)
            .WithMany(u => u.Registrations)
            .HasForeignKey(r => r.UserID)
            .OnDelete(DeleteBehavior.NoAction); // NoAction to avoid multiple cascade paths

        modelBuilder.Entity<Registration>()
            .Property(r => r.Status)
            .HasConversion<string>()  // Ensures that the enum is stored as a string in the database
            .IsRequired(false); // Allows the Status to be null by default

        modelBuilder.Entity<EventCategoryMapping>()
            .HasOne(ecm => ecm.Event)
            .WithMany(e => e.EventCategoryMappings)
            .HasForeignKey(ecm => ecm.EventID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete for EventCategoryMappings when the Event is deleted

        modelBuilder.Entity<EventCategoryMapping>()
            .HasOne(ecm => ecm.EventCategory)
            .WithMany(ec => ec.EventCategoryMappings)
            .HasForeignKey(ecm => ecm.CategoryID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete for EventCategoryMappings when the Category is deleted

        // Configure primary key of City not to be an identity column
        modelBuilder.Entity<City>()
            .Property(c => c.PostalCode)
            .ValueGeneratedNever();
    }
}
