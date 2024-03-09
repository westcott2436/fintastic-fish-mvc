using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleApplication.Entities;

public partial class FintasticFishContext : DbContext
{
    public FintasticFishContext()
    {
    }

    public FintasticFishContext(DbContextOptions<FintasticFishContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Fish> Fish { get; set; }

    public virtual DbSet<FishFood> FishFoods { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodType> FoodTypes { get; set; }

    public virtual DbSet<WaterType> WaterTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:LocalDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountyId);

            entity.ToTable("Country");

            entity.Property(e => e.CountyId).HasColumnName("CountyID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Fish>(entity =>
        {
            entity.Property(e => e.FishId).HasColumnName("FishID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.WaterTypeId).HasColumnName("WaterTypeID");

            entity.HasOne(d => d.Country).WithMany(p => p.Fish)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fish_Country");
        });

        modelBuilder.Entity<FishFood>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FishFood");

            entity.Property(e => e.FishId).HasColumnName("FishID");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");

            entity.HasOne(d => d.Fish).WithMany()
                .HasForeignKey(d => d.FishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FishFood_Fish");

            entity.HasOne(d => d.Food).WithMany()
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FishFood_Food");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.ToTable("Food");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.FoodTypeId).HasColumnName("FoodTypeID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<FoodType>(entity =>
        {
            entity.ToTable("FoodType");

            entity.Property(e => e.FoodTypeId).HasColumnName("FoodTypeID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<WaterType>(entity =>
        {
            entity.ToTable("WaterType");

            entity.Property(e => e.WaterTypeId).HasColumnName("WaterTypeID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
