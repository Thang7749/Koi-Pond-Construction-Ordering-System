using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Evaluate;

public class AppDbContext : DbContext
{
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

      
        modelBuilder.Entity<Rating>()
            .Property(r => r.RatingValue)
            .IsRequired();
        modelBuilder.Entity<Feedback>()
            .Property(r => r.FeedbackContent)
            .IsRequired();
    }
}